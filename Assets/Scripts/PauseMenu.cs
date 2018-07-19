using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;

	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvus;
	
	// Update is called once per frame
	void Update () {


		if (isPaused) {
			pauseMenuCanvus.SetActive (true);
			Time.timeScale = 0f;
			// if paused then stop the time for the game
		} else {
			pauseMenuCanvus.SetActive (false);
			Time.timeScale = 1f;
			// else let the whole game start again
		}

		if (Input.GetButtonDown ("Pause")) {
			isPaused = !isPaused;
		}
		// Button to press pause
	}

	public void Resume(){
		isPaused = false;
	}

	public void LevelSelect(){
		isPaused = false;
		Application.LoadLevel (levelSelect);
	}

	public void Quit (){
		isPaused = false;
		Application.LoadLevel (mainMenu);
	}
}
