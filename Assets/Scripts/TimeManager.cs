using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;

	private float countingTime;

	private Text theText;

	private PauseMenu thePauseMenu;

	private HealthManager theHealth;

	//public GameObject gameOverScreen;

	//public PlayerController player;

	// Use this for initialization
	void Start () {

		countingTime = startingTime;

		theText = GetComponent<Text> ();

		thePauseMenu = FindObjectOfType<PauseMenu> ();

		theHealth = FindObjectOfType<HealthManager> ();

		//player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused) {
			return;
		}

		countingTime -= Time.deltaTime;

		if (countingTime <= 0) {
			//gameOverScreen.SetActive (true);
			//player.gameObject.SetActive (false);
			theHealth.KillPlayer();
			countingTime = 0;
		}

		theText.text = "" + Mathf.Round(countingTime);
	}

	public void ResetTime(){
		countingTime = startingTime;
	}
}
