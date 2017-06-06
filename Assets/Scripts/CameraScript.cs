using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform player;
	public Transform camTransform;
	private Vector3 offset;

	float playerRotation;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
		camTransform = transform;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.position + offset;
		float angle = Quaternion.Angle (player.rotation, transform.rotation);
		Quaternion rotation = Quaternion.Euler (0, 0, angle);
		camTransform.rotation = rotation;
	}
}
