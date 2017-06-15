using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour {

    Canvas PauseMenuCanvas, MainMenuCanvas, OptionsMenuCanvas;

    public enum GameState
    {
        MainMenu,
        OptionsMenu,
        PauseMenu,
        Playing,
    }

    public GameState currentState;
	
	void Start () {
        PauseMenuCanvas = GameObject.Find("PauseMenu").gameObject.GetComponent<Canvas>();
        MainMenuCanvas = GameObject.Find("MainMenu").gameObject.GetComponent<Canvas>();
        OptionsMenuCanvas = GameObject.Find("OptionsMenu").gameObject.GetComponent<Canvas>();
        ChangeState(GameState.MainMenu);
    }
	
	
	void Update () {
		
	}

    //--------- State Machine ----------
    IEnumerator MainMenuState()
    {
        MainMenuCanvas.enabled = true;
        while (currentState == GameState.MainMenu)
        {
            yield return null;
        }

        MainMenuCanvas.enabled = false;
    }

    IEnumerator OptionsMenuState()
    {
        OptionsMenuCanvas.enabled = true;
        while (currentState == GameState.OptionsMenu)
        {
            yield return null;
        }

        OptionsMenuCanvas.enabled = false;
    }

    IEnumerator PauseMenuState()
    {
        PauseMenuCanvas.enabled = true;
        while (currentState == GameState.PauseMenu)
        {
            yield return null;
        }

        PauseMenuCanvas.enabled = false;
    }

    IEnumerator PlayingState()
    {

        while (currentState == GameState.Playing)
        {
            yield return null;
        }

    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        StartCoroutine(newState.ToString() + "State");
    }
}
