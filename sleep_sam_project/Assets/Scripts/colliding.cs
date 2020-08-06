using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliding : MonoBehaviour
{
	public cameraShake shaker;
	public GameObject deathParticles; 
	//private GameObject objectHit;
	bool isDead = false;

	void OnCollisionEnter(Collision collision) 
	{
		//objectHit = gameObject;

		//Instantiate(collisionParticleSystem, PlayerRggedMirrorApplied.transform.position, Quaternion.identity);
		if ((collision.gameObject.tag == "obstacleTag") || (collision.gameObject.tag == "wallTag")){
			if (collision.gameObject.tag == "obstacleTag"){
				collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				//collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
				//collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 250f);
			}

			//if the colliding script is disabled, then the camera shake script won't be called.
			if (GameObject.Find("Head").GetComponent<colliding>().enabled == true){
				StartCoroutine(shaker.Shake(0.13f, 0.25f));
			}

			setIsDeath();

			foreach (GameObject objects in GameObject.FindGameObjectsWithTag("standardBodyPart")){
				objects.GetComponent<colliding>().enabled = false;
			}

			//look for every object with another tag? it only searches for a movingbodyparttag.
			foreach (GameObject objects in GameObject.FindGameObjectsWithTag("movingBodyPart")){
				if (objects.GetComponent<ragdollMovement>().enabled == true){
					objects.GetComponent<ragdollMovement>().enabled = false;
				}
				objects.GetComponent<colliding>().enabled = false;
			}
		}
	}

	public void setIsDeath(){		
		int increment = 0;
		foreach (GameObject objects in GameObject.FindGameObjectsWithTag("standardBodyPart")){
			if (objects.GetComponent<colliding>().getIsDeath() == true){
				increment++;
			}
		}

		foreach (GameObject objects in GameObject.FindGameObjectsWithTag("movingBodyPart")){
			if (objects.GetComponent<colliding>().getIsDeath() == true){
				increment++;
			}
		}

		if (isDead == false && increment == 0){
			isDead = true;
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			//GameObject particlesSpawned = Instantiate(deathParticles, transform.position, Quaternion.identity);
			//Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			//Vector3 gameObjVelocity = rb.velocity;
			//particlesSpawned.GetComponent<Rigidbody>().velocity = gameObjVelocity; 
			//get velocity of the object hit and set it to the velocity of the particles spawned
		}
	}

	public bool getIsDeath(){
		return isDead;
	}

}