using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Text.RegularExpressions;

public class ObjectPooler : MonoBehaviour
{
    // Note:
    // num of active stages must be atleast the same size as the size as the stage object pool. 
    // column obstacles: 4 * number of column stages in pool
    // stages: num of stages should be 3
    
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private List<string> stageTags;

    #region Singleton Instance
    public static ObjectPooler Instance; 

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        stageTags = new List<string>();

        foreach (Pool p in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(p.tag, objectPool);

            if (Regex.IsMatch(p.tag, @"[_a-z_A-Z_]*[Ss][Tt][Aa][Gg][Ee][_a-z_A-Z_]*")){
                stageTags.Add(p.tag);
            }
        }
    }

    public GameObject spawnFromPool(string tag, Vector3 pos, Quaternion rotation) {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public string selectRandomStage() {
        return stageTags[Random.Range(0, stageTags.Count)];
    }

}
