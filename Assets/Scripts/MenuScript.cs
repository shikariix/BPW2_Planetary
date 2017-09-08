using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Button startButton;
	public GameObject menu;
    public Camera mainCamera;

	void Start() {
		startButton.onClick.AddListener (() => {
			StartGame ();
		});
	}

	void StartGame() {
		SceneManager.LoadScene ("Level1", LoadSceneMode.Additive);
		menu.SetActive (false);
        mainCamera.enabled = false;
	}
}
