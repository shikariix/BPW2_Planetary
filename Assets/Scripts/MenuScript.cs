using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public Button startButton;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener (() => {
			StartGame ();
		});
	}

	void StartGame () {
		SceneManager.LoadScene ("Level1", LoadSceneMode.Additive);
		menu.SetActive (false);
	}
}
