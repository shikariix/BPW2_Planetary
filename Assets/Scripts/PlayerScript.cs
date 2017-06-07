using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Rigidbody2D rb;
	public float jump;
	public float maxSpeed = 5f;

	private Transform currentPlanet;
	private bool canJump = false;
	bool facingRight = true;

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
		} else {
			rb.AddForce (transform.right * 0);
			rb.velocity = new Vector2 (0, 0);
		}
		transform.up -= currentPlanet.position - transform.position;
			
	}

	void Flip () {
		facingRight = !facingRight;
	}
}
