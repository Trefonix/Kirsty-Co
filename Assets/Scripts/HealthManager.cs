using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth; // The Maximum health of the player

	public static int playerHealth;	// Player current health

	public Slider healthBar; //Makes a healthbar slider corrosponding with Unity's assets

	private LevelManager levelManager; //Links with the LevelManager script

	public bool isDead; //If the player is dead var

	private LifeManager lifeSystem; //Links the Life Manager script

	private TimeManager theTime; // Links the Time Manager script

	// Use this for initialization
	void Start () {

		healthBar = GetComponent<Slider> (); //Corrosponts with the Slider Component on the health bar

		playerHealth = maxPlayerHealth; //Starts off with the player's health being maxed

		levelManager = FindObjectOfType<LevelManager> (); //Links Level Manger Script

		lifeSystem = FindObjectOfType<LifeManager> (); //Links Life Manager Script

		theTime = FindObjectOfType<TimeManager> (); // Links Time Manager script

		isDead = false; // Player is not dead

	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) 
		{
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
			// If player's health is lower than 0 and isDead is false, player's Health is still 0, calls LevelManger RespawnPlayer function, LifeManager's TakeLife Function and isDead is true.

		}
		if (playerHealth > maxPlayerHealth) {
			playerHealth = maxPlayerHealth;
			// Player's health will not go over max
		}


		healthBar.value = playerHealth;
		// The value of the health bar links with player's health
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
		// players health goes down by whatever the value of damage to Give is.
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;	
	}

	public void KillPlayer(){
		playerHealth = 0;
	}
}
