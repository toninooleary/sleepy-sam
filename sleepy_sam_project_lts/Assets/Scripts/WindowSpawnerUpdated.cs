using UnityEngine;

public class WindowSpawnerUpdated : MonoBehaviour
{

    public Transform[] spawningPoints;
    ObjectPooler objectPooler;

    public void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void OnEnable()
    {
        for (int i = 0; i <= spawningPoints.Length - 1; i++)
        {
            int spawnProbability = Random.Range(0, 10);
            if (spawnProbability <= 2)
            {
                objectPooler.spawnFromPool("Window", spawningPoints[i].position, spawningPoints[i].rotation);
            }
        }
    }
}
