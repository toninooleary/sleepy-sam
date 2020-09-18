using UnityEngine;

public class WindowSpawnerUpdated : MonoBehaviour
{

    public Transform[] spawningPoints;

    public GameObject window;
    private GameObject windowSpawned;
    public int numOfWindows;
    public int minNumOfWindows;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        for (int i = 0; i <= spawningPoints.Length; i++)
        {
            int spawnProbability = Random.Range(0, 10);
            if (spawnProbability <= 3)
            {
                windowSpawned = Instantiate(window, spawningPoints[i].position, window.transform.rotation);
                windowSpawned.transform.SetParent(gameObject.transform);
            }
        }
    }

    private void OnDisable()
    {
        
    }
}
