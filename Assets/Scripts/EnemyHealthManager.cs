using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth; //How much health the enemy has

	public GameObject deathEffect; //What Gameobject it plays when the enemy is dead

	public int pointsOnDeath; //Adds points for when player defeats enemy

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) 
		{
			Instantiate (deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints (pointsOnDeath);
			Destroy (gameObject);
			//If enemy Health is 0 the spawns a Death Particle, Add points to Score Scripts and then Destroys this object
		}
	}

	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;
	//If the function is called then gives damage to enemies health
	}
}
