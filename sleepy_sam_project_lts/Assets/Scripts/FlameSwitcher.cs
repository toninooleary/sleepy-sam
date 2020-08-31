using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSwitcher : MonoBehaviour
{
    GameObject spawnTL;
    GameObject spawnBL;
    GameObject spawnTR;
    GameObject spawnBR;
    GameObject bottomFlame;
    GameObject topFlame;
    int currentSide;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        bottomFlame = GameObject.Find("BottomFlameParticles");
        topFlame = GameObject.Find("TopFlameParticles");
        spawnTL = GameObject.Find("FlameSpawnPointTL");
        spawnBL = GameObject.Find("FlameSpawnPointBL");
        spawnTR = GameObject.Find("FlameSpawnPointTR");
        spawnBR = GameObject.Find("FlameSpawnPointBR");
        //spawns flames on the left or tight
        int currentSide = UnityEngine.Random.Range(0, 2);
        Debug.Log(currentSide);
        setSide();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5) {
            // using the XOR operator to switch sides
            currentSide = currentSide ^ 1;
            setSide();
            bottomFlame.GetComponent<ParticleSystem>().Play();
            topFlame.GetComponent<ParticleSystem>().Play();
            timer = 0;
        }
    }

    // called to move the flame to the left or right of the stage
    void setSide() {
        // moves flames to left side
        if (currentSide == 0)
        {
            bottomFlame.transform.position = spawnBL.transform.position;
            topFlame.transform.position = spawnTL.transform.position;
        }
        // moves flames to right side
        else
        {
            bottomFlame.transform.position = spawnBR.transform.position;
            topFlame.transform.position = spawnTR.transform.position;
        }
    }
}
