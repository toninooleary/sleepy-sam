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
    
    GameObject bottomDeathBoundary;
    GameObject topDeathBoundary;

    // Start is called before the first frame update
    void Start()
    {
        bottomFlame = this.transform.Find("BottomFlameParticles").gameObject;
        topFlame = this.transform.Find("TopFlameParticles").gameObject;
        spawnTL = this.transform.Find("FlameSpawnPointTL").gameObject;
        spawnBL = this.transform.Find("FlameSpawnPointBL").gameObject;
        spawnTR = this.transform.Find("FlameSpawnPointTR").gameObject;
        spawnBR = this.transform.Find("FlameSpawnPointBR").gameObject;
        bottomDeathBoundary = bottomFlame.transform.Find("DeathBoundary").gameObject;
        topDeathBoundary = topFlame.transform.Find("DeathBoundary").gameObject;
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
        if (timer >= 4.4)
        {
            bottomDeathBoundary.SetActive(false);
            topDeathBoundary.SetActive(false);
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
        bottomDeathBoundary.SetActive(true);
        topDeathBoundary.SetActive(true);
    }
}
