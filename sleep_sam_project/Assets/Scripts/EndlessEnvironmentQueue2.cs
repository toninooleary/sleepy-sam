using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessEnvironmentQueue2 : MonoBehaviour
{
    public GameObject environmentObj;
    public GameObject groundObj;
    Transform spawnPoint;
    GameObject prevObj;
    GameObject garbage;
    Queue environmentQueue = new Queue();
    GameObject tempObj;
    GameObject trigger;
    int counter = 0;
    private Text ScoreTracker;

    private ScoreCameraShake shaking;

    void Start(){
        shaking = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<ScoreCameraShake>();

        prevObj = GameObject.Find("Environment2");
        environmentQueue.Enqueue(prevObj);
    }

    void OnTriggerEnter(Collider other){

        if (other.name == "Head"){
            
            //deltes and replaces old obj
            if (counter >= 1){

                //removes last environment
                prevObj = (GameObject)environmentQueue.Peek();

                //ground spawn point
                Transform groundSpawnPoint = GameObject.Find("/" + ((GameObject)environmentQueue.Peek()).name + "/GroundSpawnPoint").transform;
                //spawn ground prefab
                tempObj = Instantiate(groundObj, groundSpawnPoint.position, groundSpawnPoint.rotation);
                //set as a parent to the object
                tempObj.transform.SetParent(GameObject.Find(((GameObject)environmentQueue.Peek()).name).transform);

            }
            //moves the environment spawner trigger.
            trigger = GameObject.Find("/" + prevObj.name + "/TriggerSpawnPoint");
            this.transform.position = trigger.transform.position;
            
            //instantiates next environment
            spawnPoint = GameObject.Find("/" + prevObj.name + "/EndlessSpawnPoint").transform;
            tempObj = Instantiate(environmentObj, spawnPoint.position, spawnPoint.rotation);
            environmentQueue.Enqueue(tempObj);

            garbage = (GameObject)environmentQueue.Dequeue();

            counter++;
        }

        ScoreTracker = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreTracker.text = counter.ToString();
        
        shaking.CameraShake();

    }
}
