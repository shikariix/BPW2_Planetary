using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript Singleton { get; private set; }

	public Rigidbody2D rb;
	public float jump;
	public float maxSpeed = 5f;
    public Vector3 spawn;

	private Animator anim;
    private AudioSource sound;
    private Transform currentPlanet;
	private bool canJump = false;
	bool facingRight = true;

	void Awake() {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
		
	}

	void Start() {
		anim = GetComponent<Animator> ();
        spawn = gameObject.transform.position;
        sound = GetComponent<AudioSource>();
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

		if (Input.GetButtonDown ("Jump") && canJump) {
            //find something else for this?
			rb.AddForce (transform.up * jump);
			canJump = false;
            sound.Play();
			anim.SetBool ("isFloating", true);
		}
		if (!canJump) {
			anim.SetBool ("isIdle", false);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
        //only allow jumping after hitting ground to avoid endless jumps
		if (col.gameObject.tag == "Planet") {
			canJump = true;
		}
		anim.SetBool ("isFloating", false);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.tag == "Planet")
        {
            currentPlanet = col.transform;
        }
    }

    void FixedUpdate () {
        float move = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (transform.right * move * maxSpeed);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isIdle", false);
			Flip ();
		} else if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (transform.right * move * maxSpeed);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isIdle", false);
			Flip ();
		} else {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isIdle", true);
		}
			
		if (currentPlanet != null) {
			transform.up -= currentPlanet.position - transform.position;
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
