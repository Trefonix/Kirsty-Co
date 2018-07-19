using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour {

	public LevelManager levelManager;

	private LifeManager lifeSystem;

	private PlayerController kbplayer;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		lifeSystem = FindObjectOfType<LifeManager> ();
		kbplayer = FindObjectOfType<PlayerController> ();
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
		}
	}
}
