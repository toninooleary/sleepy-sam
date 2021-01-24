using UnityEngine;

public class WindowSpawner : MonoBehaviour
{

    public GameObject[] windows;

    private void OnEnable()
    {
        for (int i = 0; i <= windows.Length - 1; i++)
        {
            int spawnProbability = Random.Range(0, 10);
            if (spawnProbability <= 2)
            {
                windows[i].SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject obj in windows)
        {
            obj.SetActive(false);
        }
    }
}
