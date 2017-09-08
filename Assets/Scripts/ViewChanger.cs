﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewChanger : MonoBehaviour {

	public static ViewChanger Singleton { get; private set; }
	private StateMachineManager gameManager;

	//Singleton
	void Awake() {
		if (Singleton == null) {
			Singleton = this;
			DontDestroyOnLoad(gameObject);
		} 
		else {
			Destroy(gameObject);
		}
	}
		
	void Start() {
        gameManager = FindObjectOfType<StateMachineManager>();
    }

	//Change the state
    public void MainMenu() {
        gameManager.ChangeState(StateMachineManager.GameState.MainMenu);
    }

    public void Options() {
        gameManager.ChangeState(StateMachineManager.GameState.OptionsMenu);
    }

    public void Pause() {
        gameManager.ChangeState(StateMachineManager.GameState.PauseMenu);
    }

	public void Quit() {
        Debug.Log("You cannot quit in the editor!");
        Application.Quit();
    }

	public void Playing() {
		SceneManager.LoadScene ("Level1");
        gameManager.ChangeState(StateMachineManager.GameState.Playing);
    }
}
