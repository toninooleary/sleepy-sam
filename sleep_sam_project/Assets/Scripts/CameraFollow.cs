using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform player;

	public float smoothTime = 0.125f;
	public Vector3 offset;
	private Vector3 velocity = Vector3.zero;
	float bias = 0.50f;

	//working
	// void FixedUpdate(){
	// 	Vector3 wantedPosition = player.position + offset;
	// 	Vector3 smoothedWantedPosition = (transform.position * bias) + (wantedPosition * (1.0f-bias)); 
	// 	//transform.position = smoothedWantedPosition;
	// 	// Lerp smooths from one point to another. It takes in (a starting position, the desired position or end point, a float (t) over time)
	// 	// when t is 0 it gives us the starting position. when it's one it gives us the end position.
	// 	//Vector3 smoothPosition = Vector3.Lerp(transform.position, wantedPosition, smoothTime);
	// 	Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, smoothedWantedPosition, ref velocity, smoothTime);
	// 	transform.position = smoothPosition;
	// }

	//working with x limits (ristrictions for how far the camera can move left and right)
	void FixedUpdate(){
		Vector3 wantedPosition = player.position + offset;
		float limit = Mathf.Clamp(wantedPosition.x, -2.5f, 2.5f);
		wantedPosition.x = limit;
		Vector3 smoothedWantedPosition = (transform.position * bias) + (wantedPosition * (1.0f-bias));
		Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, smoothedWantedPosition, ref velocity, smoothTime);
		transform.position = smoothPosition;
	}
}
