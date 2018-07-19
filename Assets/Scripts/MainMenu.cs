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
		//Remebers Players Lives and makes new lives
		PlayerPrefs.SetInt ("CurrentScore", 0);
		//Remembers CurrentScore and sets the score at 0

		PlayerPrefs.SetInt (Level1Tag, 1);
		//Goes to first level
		Application.LoadLevel (startLevel);
		//Loads First Level Scene
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentScore", 0);
		PlayerPrefs.SetInt (Level1Tag, 1);
		Application.LoadLevel (levelSelect);
		//Same as above but goes to Level Select Scene
	}

	public void QuitGame()
	{
		Application.Quit ();
		//Quits the whole game
	}
}
