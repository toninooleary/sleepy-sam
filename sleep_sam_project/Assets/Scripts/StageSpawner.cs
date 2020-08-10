using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSpawner : MonoBehaviour
{
    public GameObject environmentObj;
    public GameObject groundObj;
    Transform spawnPoint;
    GameObject prevObj;
    GameObject garbage;
    Queue environmentQueue = new Queue();
    GameObject tempObj;
    GameObject trigger;
    GameObject currentObj;
    int counter = 0;
    private Text ScoreTracker;

    private ScoreCameraShake shaking;

    void Start(){
        shaking = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<ScoreCameraShake>();
        
        environmentQueue.Enqueue(GameObject.Find("Environment"));
        environmentQueue.Enqueue(GameObject.Find("Environment2"));
        currentObj = GameObject.Find("Environment2");
    }

    void OnTriggerEnter(Collider other){

        if (other.name == "Head"){
            
            //deltes and replaces old obj
            if (counter >= 2){
                GameObject obj = (GameObject)environmentQueue.Dequeue();

                //ground spawn point
                Transform groundSpawnPoint = GameObject.Find("/" + ((GameObject)environmentQueue.Peek()).name + "/GroundSpawnPoint").transform;
                //spawn ground prefab
                //do ground.setactive instead
                tempObj = Instantiate(groundObj, groundSpawnPoint.position, groundSpawnPoint.rotation);
                
                //set as a parent to the object
                tempObj.transform.SetParent(GameObject.Find(((GameObject)environmentQueue.Peek()).name).transform);
                
                //do object pooling instead
                //remove environment
                Destroy(obj);
            }
            //moves the environment spawner trigger.
            trigger = GameObject.Find("/" + currentObj.name + "/TriggerSpawnPoint");
            this.transform.position = trigger.transform.position;
            
            //instantiates next environment
            spawnPoint = GameObject.Find("/" + currentObj.name + "/EndlessSpawnPoint").transform;
            tempObj = Instantiate(environmentObj, spawnPoint.position, spawnPoint.rotation);
            environmentQueue.Enqueue(tempObj);
            currentObj = tempObj;
            currentObj.name = currentObj.name + counter;

            counter++;
        }

        ScoreTracker = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreTracker.text = counter.ToString();
        
        shaking.CameraShake();

    }
}