using UnityEngine;

public class WindowSpawner : MonoBehaviour
{

    public Transform[] spawningPoints;

    public GameObject window;
    private GameObject windowSpawned;
    public int numOfWindows;
    public int minNumOfWindows;

    // Start is called before the first frame update
    void Start()
    {
        //makes number of windows requested from unity editor accurate
        numOfWindows++;

        numOfWindows = Random.Range(minNumOfWindows, numOfWindows);
        int[] rand = new int[numOfWindows];

        bool duplicated = false;
        do{
            duplicated = false;
            //selects spawn points for windows
            for (int i = 0; i < numOfWindows; i++){
                rand[i] = Random.Range(0, spawningPoints.Length);
            }
            //sorting algorithm
            for (int i = 0; i < numOfWindows - 1; i++){
                if (rand [i] > rand[i + 1]){
                    int temp = rand[i + 1];
                    rand[i] = rand[i + 1];
                    rand[i + 1] = temp;
                }
            }
            //duplicate check
            for (int i = 0; i < numOfWindows - 1; i++){
                if (rand[i] == rand[i + 1]){
                    duplicated = true;
                }
            }
        } while (duplicated == true);

        //instantiating windows
        for (int i = 0; i < spawningPoints.Length; i++){
            for (int j = 0; j < numOfWindows; j++){
                if (rand[j] == i){
                    windowSpawned = Instantiate(window, spawningPoints[i].position, window.transform.rotation);
                    windowSpawned.transform.SetParent(gameObject.transform);
                }
            }
        }
    }
}
