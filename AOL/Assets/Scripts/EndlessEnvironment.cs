using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessEnvironment : MonoBehaviour
{
    public GameObject environmentObj;

    Transform spawnPoint;
    GameObject objectTracker;
    int increment = 0;
    
    private Text ScoreTracker;
    private ScoreCameraShake shaking;

    void Start(){
        shaking = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<ScoreCameraShake>();
    }

    void OnTriggerEnter(Collider other){

        if (other.name == "Head"){
            Debug.Log("Enter");

            if (increment >= 1){
                //destroys old Environment
                objectTracker = GameObject.Find("Environment");
                objectTracker.name = "TempName";
                Destroy(objectTracker);

                /** renames the previous environment to compensate
                for the next environment to be instatiated.*/
                objectTracker = GameObject.Find("NewEnvironment");
                objectTracker.name = "Environment";
                //if (increment >= 2){
                    //https://forum.unity.com/threads/find-gameobject-then-setactive.200919/
                    //You can only find objects that are active
                    //otherwise you must instantiate it.
                    // GameObject.Find("/Environment/Ground").SetActive(true);
                // }
            }

            //finds where to spawn the next environment
            objectTracker = GameObject.Find("/Environment/EndlessSpawnPoint");
            spawnPoint = objectTracker.transform;

            //instantiates next environment
            objectTracker = Instantiate(environmentObj, spawnPoint.position, spawnPoint.rotation);
            objectTracker.name = "NewEnvironment";

            //moves the environment spawner trigger.
            objectTracker = GameObject.Find("/NewEnvironment/TriggerSpawnPoint");
            this.transform.position = objectTracker.transform.position;

            increment++;
        }
        ScoreTracker = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreTracker.text = increment.ToString();
        
        shaking.CameraShake();

    }

}

