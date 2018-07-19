using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public LevelManager levelManager; //Finds the level Manager Script

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		// Finds the level Manger script
	}
	
	// Update is called once per frame
	void Update () {
			}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			levelManager.currentCheckpoint = gameObject;
			//If this checkpoint hits player, tell level Manager script to mark as current checkpoint
		}
	}
}
