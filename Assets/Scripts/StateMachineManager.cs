using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour {

	public static StateMachineManager Singleton { get; private set; }
	public GameState currentState;
    private Canvas PauseMenuCanvas, MainMenuCanvas, OptionsMenuCanvas;

	private GameObject player;
	private PlayerScript controls;
	private StickyTongue tongue;

    public enum GameState {
        MainMenu,
        OptionsMenu,
        PauseMenu,
        Playing,
    }

	//Singleton
	void Awake() {
		if (Singleton == null)
		{
			Singleton = this;
			DontDestroyOnLoad(gameObject);
		} 
		else {
			Destroy(gameObject);
		}
	}

	void Start() {
        PauseMenuCanvas = GameObject.Find("PauseMenu").gameObject.GetComponent<Canvas>();
        MainMenuCanvas = GameObject.Find("MainMenu").gameObject.GetComponent<Canvas>();
        OptionsMenuCanvas = GameObject.Find("OptionsMenu").gameObject.GetComponent<Canvas>();
		player = GameObject.FindWithTag ("Player");
        ChangeState(GameState.MainMenu);
    }

    //State Machine
    IEnumerator MainMenuState() {
        MainMenuCanvas.enabled = true;
		player.SetActive (false);
        while (currentState == GameState.MainMenu) {
            yield return null;
        }

        MainMenuCanvas.enabled = false;
    }

    IEnumerator OptionsMenuState() {
        OptionsMenuCanvas.enabled = true;
        while (currentState == GameState.OptionsMenu) {
            yield return null;
        }
        OptionsMenuCanvas.enabled = false;
    }

    IEnumerator PauseMenuState() {
        PauseMenuCanvas.enabled = true;
		controls = player.GetComponent<PlayerScript>();
		tongue = player.GetComponent<StickyTongue>();
		controls.enabled = false;
		tongue.enabled = false;
        while (currentState == GameState.PauseMenu) {
            yield return null;
        }
        PauseMenuCanvas.enabled = false;
		controls.enabled = true;
		tongue.enabled = true;
    }

    IEnumerator PlayingState() {
		player.SetActive(true);
        while (currentState == GameState.Playing) {
            yield return null;
        }
    }

    public void ChangeState(GameState newState) {
        currentState = newState;
        StartCoroutine(newState.ToString() + "State");
    }
}
