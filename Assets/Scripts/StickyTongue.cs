using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTongue : MonoBehaviour {

	private SpringJoint2D spring;
	private Animator sprite;
	public GameObject tongue;

	Vector3 scale;
	Vector3 targetPos;
	RaycastHit2D hit;

	public float distance = 10f;
	public LayerMask mask;

	void Start () {
		spring = GetComponent<SpringJoint2D> ();
		sprite = GetComponent<Animator> ();
		sprite.SetBool ("usingTongue", false);
		tongue.SetActive (false);
		scale = tongue.transform.localScale;
	}

	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			//change the sprite to an open mouth;
			sprite.SetBool("usingTongue", true);

			//raycasting
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPos.z = 0;

			hit = Physics2D.Raycast (transform.position, targetPos-transform.position, distance, mask);

			if (hit.collider != null) {
				//this should actually connect to a rigidbody;
				spring.enabled = true;
				spring.connectedBody = hit.rigidbody;
				spring.connectedAnchor = targetPos;

				tongue.SetActive(true);

			} 

		}
		if (Input.GetButton ("Fire1")) {
			sprite.SetBool ("isIdle", false);
			sprite.SetBool ("isWalking", false);
			sprite.SetBool ("isFloating", false);

			tongue.transform.right = targetPos - tongue.transform.position;
			tongue.transform.position = (transform.position + targetPos) / 2;
			scale.Set (Vector2.Distance (tongue.transform.position, targetPos)+0.5f, scale.y, scale.z);
			tongue.transform.localScale = scale;
		}

		if (Input.GetButtonUp ("Fire1")) {
			spring.enabled = false;
			sprite.SetBool ("usingTongue", false);
			tongue.SetActive(false);
		}
	}
}
