using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSwitcher : MonoBehaviour
{
    String currentSide;
    private float timer;
    GameObject spawnTL;
    GameObject spawnBL;
    GameObject spawnTR;
    GameObject spawnBR;
    GameObject bottomFlame;
    GameObject topFlame;

    // Start is called before the first frame update
    void Start()
    {
        int startingSide = UnityEngine.Random.Range(0, 2);
        bottomFlame = GameObject.Find("BottomFlameParticles");
        topFlame = GameObject.Find("TopFlameParticles");
        spawnTL = GameObject.Find("FlameSpawnPointTL");
        spawnBL = GameObject.Find("FlameSpawnPointBL");
        spawnTR = GameObject.Find("FlameSpawnPointTR");
        spawnBR = GameObject.Find("FlameSpawnPointBR");
        //spawns flames on the left
        if (startingSide == 0)
        {
            bottomFlame.transform.position = spawnBL.transform.position;
            topFlame.transform.position = spawnTL.transform.position;
            currentSide = "left";
        }
        // spawns flames on the right
        else 
        {
            bottomFlame.transform.position = spawnBR.transform.position;
            topFlame.transform.position = spawnTR.transform.position;
            currentSide = "right";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        Debug.Log(UnityEngine.Random.Range(0, 2));
        // switches flame to right side
        if (timer >= 5) {
            if (currentSide == "left")
            {
                bottomFlame.transform.position = spawnBR.transform.position;
                topFlame.transform.position = spawnTR.transform.position;
                bottomFlame.GetComponent<ParticleSystem>().Play();
                topFlame.GetComponent<ParticleSystem>().Play();
                timer = 0;
                currentSide = "right";
            }
            // switches flame to left side
            else
            {
                bottomFlame.transform.position = spawnBL.transform.position;
                topFlame.transform.position = spawnTL.transform.position;
                bottomFlame.GetComponent<ParticleSystem>().Play();
                topFlame.GetComponent<ParticleSystem>().Play();
                timer = 0;
                currentSide = "left";
            }
        }
    }
}
