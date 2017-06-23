using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu instance { get; private set; }
	StateMachineManager state;

	void Awake () {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}

	void Start() {
		state = GameObject.FindObjectOfType<StateMachineManager> ();
	}

	void Update() {
		if (Input.GetKey (KeyCode.Escape)) {
			state.ChangeState(StateMachineManager.GameState.PauseMenu);

		}
	}
}
