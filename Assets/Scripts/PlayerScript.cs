using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript Singleton { get; private set; }

	public Rigidbody2D rb;
	public float jump;
	public float maxSpeed = 5f;

	private Animator anim;
    private AudioSource sound;
    private Transform currentPlanet;
	private bool canJump = false;
	bool facingRight = true;

	void Start() {
		if (Singleton == null)
		{
			Singleton = this;
			DontDestroyOnLoad(gameObject);
		} else
		{
			Destroy(gameObject);
		}

		anim = GetComponent<Animator> ();
        sound = GetComponent<AudioSource>();
    }
    
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
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
			currentPlanet = col.transform;
		}
		anim.SetBool ("isFloating", false);
	}

     void OnTriggerEnter2D(Collider2D col)
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
}
