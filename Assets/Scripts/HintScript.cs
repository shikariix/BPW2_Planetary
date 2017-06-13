using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour {

	public Text hint;

	void Start () {
		hint.text = "";
	}

	void OnTriggerEnter2D (Collider2D col) {
		hint.text = "Jump!";
	}

	void OnTriggerExit2D (Collider2D col) {
		hint.text = "";
	}
}
