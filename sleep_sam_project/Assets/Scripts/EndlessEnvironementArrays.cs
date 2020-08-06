using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessEnvironementArrays : MonoBehaviour
{
    public GameObject environmentObj;
    public GameObject groundObj;

    Transform spawnPoint;
    Transform GroundSpawnPoint;
    GameObject objectTracker;
    int increment = 0;
    private Text ScoreTracker;
    GameObject[] environmentArray = new GameObject[3];

    private ScoreCameraShake shaking;

    void Start(){
        shaking = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<ScoreCameraShake>();

        environmentArray[0] = GameObject.Find("Environment");
        environmentArray[1] = GameObject.Find("Environment2");
    }

    void OnTriggerEnter(Collider other){

        if (other.name == "Head"){

            if (increment >= 1){
                //destroys old Environment
                objectTracker = environmentArray[0];
                Destroy(objectTracker);

                environmentArray[0] = environmentArray[1];
                environmentArray[1] = environmentArray[2];
                environmentArray[2] = null;

                //get spawn point of environment[0]
                objectTracker = GameObject.Find("/" + environmentArray[0].name + "/GroundSpawnPoint");
                GroundSpawnPoint = objectTracker.transform;
                //spawn ground prefab
                objectTracker = Instantiate(groundObj, GroundSpawnPoint.position, GroundSpawnPoint.rotation);
                //set as a parent to the object
                objectTracker.transform.SetParent(GameObject.Find("/EnvironmentObj" + (increment - 1)).transform);
            }

            //finds where to spawn the next environment
            objectTracker = GameObject.Find("/" + environmentArray[1].name + "/EndlessSpawnPoint");
            spawnPoint = objectTracker.transform;

            //instantiates next environment
            environmentArray[2] = Instantiate(environmentObj, spawnPoint.position, spawnPoint.rotation);
            environmentArray[2].name = ("EnvironmentObj" + increment);

            //moves the environment spawner trigger.
            objectTracker = GameObject.Find("/" + environmentArray[1].name + "/TriggerSpawnPoint");
            this.transform.position = objectTracker.transform.position;

            increment++;
        }
        ScoreTracker = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreTracker.text = increment.ToString();
        
        shaking.CameraShake();

    }
}
