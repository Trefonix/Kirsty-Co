using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour {

	public LevelManager levelManager; //Links with the LevelManager Script

	private LifeManager lifeSystem; //Links of the lifeManager Script

	private PlayerController kbplayer; //Links with the PlayerController Script

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); //Links with LevelManager Script
		lifeSystem = FindObjectOfType<LifeManager> (); //Links with the LifeManager Script
		kbplayer = FindObjectOfType<PlayerController> (); //Links with the PlayerController Script
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			lifeSystem.TakeLife ();
			kbplayer.knockbackCount = 0;
			levelManager.RespawnPlayer();
			// If this hits player then takes life, knockback is 0 and LevelManger respawnPlayer function starts
		}
	}
}
