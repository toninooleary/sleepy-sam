using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollMovement : MonoBehaviour {
	
	private Rigidbody rb;
	public float upThrust;
	public float sideThrust;
	//private int counter = 0;
	private int i;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("w")) {
			rb.AddForce(0,upThrust,0 * Time.deltaTime);
		}

		//counter++;

		if (Input.GetKey("a")){
			rb.AddForce(sideThrust,0,0 * Time.deltaTime);
		}
		else if (Input.GetKey("d")){
			rb.AddForce(-sideThrust,0,0 * Time.deltaTime);
		}	

		// if(counter > 300){
		// 	rb.AddForce(0, upThrust, 0 * Time.deltaTime);
		// 	upThrust = upThrust + 0.0075f;	
		// }
	}

}