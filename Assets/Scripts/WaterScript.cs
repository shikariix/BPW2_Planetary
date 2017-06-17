using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		other.attachedRigidbody.AddForce(transform.up * -60);
	}
}
