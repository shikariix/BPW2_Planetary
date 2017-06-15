using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewChanger : MonoBehaviour {

    StateMachineManager gameManager;

	void Start () {
        gameManager = FindObjectOfType<StateMachineManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
        gameManager.ChangeState(StateMachineManager.GameState.MainMenu);
    }

    public void Options()
    {
        gameManager.ChangeState(StateMachineManager.GameState.OptionsMenu);
    }

    public void Pause()
    {
        gameManager.ChangeState(StateMachineManager.GameState.PauseMenu);
    }

    public void Quit()
    {
        Debug.Log("You cannot quit in the editor!");
        Application.Quit();
    }

    public void Playing()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        gameManager.ChangeState(StateMachineManager.GameState.Playing);
    }
}
