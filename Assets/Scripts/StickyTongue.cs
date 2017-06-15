using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTongue : MonoBehaviour {

	private SpringJoint2D spring;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;
	public LayerMask mask;

	// Use this for initialization
	void Start () {
		spring = GetComponent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPos.z = 0;


			hit = Physics2D.Raycast (transform.position, targetPos-transform.position, distance, mask);

			if (hit.collider != null) {
				//this should actually connect to a rigidbody;
				spring.enabled = true;
				spring.connectedAnchor = targetPos;
			} 
		}

		if (Input.GetButtonUp ("Fire1")) {
			spring.enabled = false;
		}
	}
}
