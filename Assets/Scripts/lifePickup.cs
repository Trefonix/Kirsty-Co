using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePickup : MonoBehaviour {

	private LifeManager lifeSystem; //Finds Life Manager script

	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
		// Finds Life Manager Script
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			lifeSystem.GiveLife ();
			Destroy (gameObject);
			//If this object hits the player then goes to Give Life function in LifeManager. Then Destroys this object.
		}
	}
}
