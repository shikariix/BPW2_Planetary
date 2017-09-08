using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu instance { get; private set; }
	StateMachineManager state;

	//Singleton
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} 
		else {
			Destroy(gameObject);
		}
	}

	//Setting the state to pause menu
	void Start() {
		state = GameObject.FindObjectOfType<StateMachineManager> ();
	}

	//Opens this menu when escape is pressed
	void Update() {
		if (Input.GetKey (KeyCode.Escape)) {
			state.ChangeState(StateMachineManager.GameState.PauseMenu);

		}
	}
}
