using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform player;

	void LateUpdate () {
		//Sets position and rotation of the camera to that of the player
		transform.position = Vector3.Lerp(transform.position, player.position + new Vector3(0, 0, -10), 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, 0.1f);
    }


}
