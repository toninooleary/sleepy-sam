using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StageSpawnerWObjectPooling : MonoBehaviour
{
    private GameObject ground;
    private Queue stageQueue = new Queue();
    private GameObject currentObj;
    int counter = 0;
    private Text ScoreTracker;
    private ScoreCameraShake shaking;
    ObjectPooler objectPooler;

    void Start()
    {
        shaking = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<ScoreCameraShake>();
        currentObj = GameObject.Find("ColumnsStage");
        stageQueue.Enqueue(GameObject.Find("StartingStage"));
        stageQueue.Enqueue(currentObj);
        ground = GameObject.Find("Ground");
        objectPooler = ObjectPooler.Instance;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Head")
        {
            // if this is changed, the number of objects for each stage must be atleast this number
            if (counter >= 2)
            {
                GameObject obj = (GameObject)stageQueue.Dequeue();
                obj.SetActive(false);
                // move ground object
                Transform groundSpawnPoint = ((GameObject)stageQueue.Peek()).transform.Find("GroundSpawnPoint");
                ground.transform.position = groundSpawnPoint.position;
            }
            //move environment spawner trigger.
            Transform triggerSpawnPoint = currentObj.transform.Find("TriggerSpawnPoint");
            this.transform.position = triggerSpawnPoint.position;

            Transform spawnPoint = currentObj.transform.Find("EndlessSpawnPoint");
            currentObj = objectPooler.spawnFromPool(objectPooler.selectRandomStage(), spawnPoint.position, spawnPoint.rotation);
            stageQueue.Enqueue(currentObj);

            counter++;
        }

        // score behaviour
        ScoreTracker = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreTracker.text = counter.ToString();
        shaking.CameraShake();
    }
}