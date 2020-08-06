using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public Transform[] spawningPoints;

    public GameObject obstacle;
    private GameObject obstacleSpawned;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, spawningPoints.Length);


        for (int i = 0; i < spawningPoints.Length; i++){
            if (rand != i){
                obstacleSpawned = Instantiate(obstacle, spawningPoints[i].position, Quaternion.identity);
                obstacleSpawned.transform.SetParent(gameObject.transform);
           }
       }
    }
}
