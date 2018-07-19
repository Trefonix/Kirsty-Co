using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime; //Starting time begining the game

	private float countingTime; //Counting Time value to go down to

	private Text theText; //Links Text Component

	private PauseMenu thePauseMenu; //Links Pause Menu Script

	private HealthManager theHealth; //Links Health Manager Script

	// Use this for initialization
	void Start () {

		countingTime = startingTime; //Starts counting down from the value of starting time

		theText = GetComponent<Text> (); //Links Text Component

		thePauseMenu = FindObjectOfType<PauseMenu> (); //Links Pause Menu Script

		theHealth = FindObjectOfType<HealthManager> (); //Links HealthManager Script

	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused) {
			return;
			//If pause Menu is true then stops this script
		}

		countingTime -= Time.deltaTime;
		//Starts countingTime down in seconds

		if (countingTime <= 0) {
			theHealth.KillPlayer();
			countingTime = 0;
			//If countingTime is 0, this script kills the player and sets the counter to = 0;
		}

		theText.text = "" + Mathf.Round(countingTime);
		//Sets the value of the text to CountingTime value
	}

	public void ResetTime(){
		countingTime = startingTime;
		//Sets counting Time to the value of startingTime
	}
}
