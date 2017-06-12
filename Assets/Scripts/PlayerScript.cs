using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public static PlayerScript singleton;

	public Rigidbody2D rb;
	public float jump;
	public float maxSpeed = 5f;
    public Vector3 spawn;

    private Transform currentPlanet;
	private SpringJoint2D spring;
	private bool canJump = false;
	bool facingRight = true;

	void Awake() {
		singleton = this;
	}

	void Start() {
		spring = GetComponent<SpringJoint2D> ();
        spawn = gameObject.transform.position;
    }

	// Update is called once per frame
	void Update () {
        //inefficient script, keeping it to show progress
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
            //find something else for this?
			rb.AddForce (transform.up * jump);
			canJump = false;
		}
			
	}

	void OnCollisionEnter2D (Collision2D col) {
        //only allow jumping after hitting ground to avoid endless jumps
		if (col.gameObject.tag == "Planet") {
			canJump = true;
			currentPlanet = col.transform;
		}

        if (col.gameObject.tag == "Water")
        {
            Invoke("Respawn", 2);
        }
	}

	void FixedUpdate () {
        float move = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (transform.right * move * maxSpeed);
            Flip();
		} else if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (transform.right * move * maxSpeed);
            Flip();
		}
			
		if (currentPlanet != null) {
			transform.up -= currentPlanet.position - transform.position;
		}

		if (Input.GetButtonUp ("Fire1")) {

			Vector3 rayOrigin = gameObject.transform.position;

			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Input.mousePosition);

			if (hit.collider.gameObject != null) {
				//spring.enabled = true;
				//spring.connectedAnchor = hit.collider.transform.position;
				//spring.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D> ();
			} 
		} 
	}

	void Flip () {
        SpriteRenderer flip = GetComponent<SpriteRenderer>();
        if (facingRight && Input.GetKey(KeyCode.A) || !facingRight && Input.GetKey(KeyCode.D))
        {
            facingRight = !facingRight;
            flip.flipX = !flip.flipX;
        }
	}

    void Respawn ()
    {
        //Instantiate(gameObject, spawn, Quaternion.identity);
        //Destroy(gameObject);
    }
}
