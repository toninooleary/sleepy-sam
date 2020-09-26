using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private DeathCameraShake shaker;
    public GameObject deathParticles;

    void Start()
    {
        shaker = GameObject.Find("CollisionShakeManager").GetComponent<DeathCameraShake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Colliding>() != null)
        {
            other.GetComponent<Colliding>().enabled = false;
        }

        if (other.GetComponent<RagdollMovement>() != null)
        {
            if (other.GetComponent<RagdollMovement>().enabled == true) 
            {
                other.GetComponent<RagdollMovement>().enabled = false;
                StartCoroutine(shaker.Shake(0.13f, 0.25f));
                Instantiate(deathParticles, transform.position, Quaternion.identity);
            }
        }
    }
}
