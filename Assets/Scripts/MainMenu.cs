using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string levelSelect;

	public int playerLives;

	public string Level1Tag;

	public void NewGame()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentScore", 0);


		PlayerPrefs.SetInt (Level1Tag, 1);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentScore", 0);
		PlayerPrefs.SetInt (Level1Tag, 1);
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame()
	{
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
}
