using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint; //Links with the Checkpoint object

	private PlayerController player; //Links with the PlayerController script

	public GameObject deathParticle; //Adds a deathparticle object NOTE:We might not be using this
	public GameObject respawnParticle; //Adds a respawnparticle object NOTE: Again we might not be using this

	public float respawnDelay; //Time before player starts level again after death

	public int pointPenaltyOnDeath; //Points go back to 0 on death

	public HealthManager healthManager; //Links with the HealthManager

	public TimeManager timeManager; // Links with the TimeManager

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //Finds Player Controller Script

		healthManager = FindObjectOfType<HealthManager> (); // Links Health Manager Script

		timeManager = FindObjectOfType<TimeManager> (); //Links with the Time Manager Script
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
		//Starts RespawnPlayerCo function and timer
	}

	public IEnumerator RespawnPlayerCo()
	{
		player.enabled = false;
		// player component is hidden
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		// Makes a death particle object
		player.gameObject.SetActive (false);
		//Deletes the gameobject temporalary
		yield return new WaitForSeconds (respawnDelay);
		//Waits a few seconds with the value of the respawnDelay var
		player.transform.position = currentCheckpoint.transform.position;
		//Player finds the checkpoint position of what was the last Checkpoint
		player.enabled = true;    
		//Player component is active again
		player.gameObject.SetActive (true);
		//Player Object comes back
		healthManager.FullHealth ();
		//Player is at full health
		healthManager.isDead = false;
		//Player is not dead
		ScoreManager.score = 0;
		//Score returns to 0
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		// Makes a respawn effect
		player.knockbackCount = 0;
		// Player's knockback is back at 0
		timeManager.ResetTime ();
		//Time is reset
	}
}
