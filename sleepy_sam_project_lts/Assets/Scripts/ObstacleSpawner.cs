using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;

    void OnEnable()
    {
        int rand = Random.Range(0, obstacles.Length);
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (rand != i)
            {
                obstacles[i].SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject obj in obstacles)
        {
            obj.SetActive(false);
        }
    }
}
