using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

public class RagdollMovement : MonoBehaviour {
	
	private Rigidbody rb;
	private float thrust;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		thrust = 25f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			// 25f represents max distance
			// layer stops the ray from hitting anything else
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200.0f, LayerMask.GetMask("ReferencePlane")))
			{
				direction = (hit.point - gameObject.transform.position).normalized;
				direction.z = 0;
			}
		}
		else {
			rb.AddForce(direction * thrust, ForceMode.Impulse);
		}
	}

}