using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	//public int startingLives;
	private int lifeCounter; //Gives a life Counter value

	private Text theText; // Makes life text in the UI

	public GameObject gameOverScreen; //Links a Game Over object in the UI

	public PlayerController player; //Links the PlayerController

	public string mainMenu; 

	public float waitAfterGameOver; //Game over screen time before going back to main menu in seconds

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text>(); //Make life text connect with lifecounter

		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives"); // links the text with lifecounter

		player = FindObjectOfType<PlayerController> (); //Links PlayerController Script
	}
	
	// Update is called once per frame
	void Update () {

		if (lifeCounter < 0) {
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
			//If player's Lives is at 0 then GameOver is active and player is Deactivated
		}

		theText.text = "x " + lifeCounter;
		//Live Counter with x and the value of lifecounter
		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
			//If gameOver is active then countdown seconds for GameOver Screen before going back to main menu
		}

		if (waitAfterGameOver < 0) {
			Application.LoadLevel (mainMenu);
			// after seconds = 0 then load Main Menu Scene
		}
	}

	public void GiveLife()
	{
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
		// Gives extra life and counter goes up
	}

	public void TakeLife()
	{
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	// Takes life and counter goes down
	}
}
