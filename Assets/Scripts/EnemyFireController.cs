using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireController : MonoBehaviour {

	public float speed; //Speed of the projectile

	public PlayerController player; //Finds player Controller script

	//public GameObject enemyDeathEffect; NOTE:Deleted Particle Effect variable

	public GameObject impactEffect; //Gameobject for projectile impact effect for when hitting say a wall or an object

	//public int pointsForKill; NOTE: Deleted Points on Kill script

	public int damageToGive; //How much damage an enemy gives to the player var

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //Finds Player Controller Script Component
		if (player.transform.position.x < transform.position.x)
			speed = -speed;
		// If player is left or right shoot in the players direction
	}
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		//Projectile constantly going right or left
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation); NOTE: Deleted Death Particle script
			//Destroy (other.gameObject); NOTE: Deleted Destroy GameObject script
			//ScoreManager.AddPoints (pointsForKill); NOTE: Deleted Add to score when defeated script

			HealthManager.HurtPlayer (damageToGive); //Goes to Health Manager Script and tells to go to the damage to Give function
		}


		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		// Makes impact particle when hitting any object and then destroys the projectile
	}
}
