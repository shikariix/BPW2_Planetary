using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Rigidbody2D rb;
	public float jump;
	public float maxSpeed = 5f;

	private Transform currentPlanet;
	private SpringJoint2D spring;
	private bool canJump = false;
	bool facingRight = true;

	void Start() {
		spring = GetComponent<SpringJoint2D> ();
	}

	// Update is called once per frame
	void Update () {
		//PlanetScript[] planets = GameObject.FindObjectsOfType<PlanetScript> ();
		//foreach (PlanetScript p in planets) {
		//	float distance = Vector3.Distance (p.transform.position, transform.position);

		//	if (distance < p.range) {
		//		float influence = 1 - (distance / p.range);
		//		rb.AddForce ((p.transform.position - transform.position).normalized * p.power * influence);

		//		
		//	}
		//}

		if (Input.GetButtonDown ("Jump") && canJump == true) {
			rb.AddForce (transform.up * jump);
			canJump = false;
		}
			
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Planet") {
			canJump = true;
			currentPlanet = col.transform;
		}
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (transform.right * move * maxSpeed);
		} else if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (transform.right * move * maxSpeed);
		}
			
		if (currentPlanet != null) {
			transform.up -= currentPlanet.position - transform.position;
			//spring.enabled = true;
			//spring.connectedAnchor = currentPlanet.position;
		}

		if (Input.GetButtonUp ("Fire1")) {

			Vector3 rayOrigin = gameObject.transform.position;

			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Input.mousePosition);

			if (hit.collider.gameObject != null) {
				spring.enabled = true;
				spring.connectedAnchor = Input.mousePosition;
			} 
		} 
	}

	void Flip () {
		facingRight = !facingRight;
	}
}
