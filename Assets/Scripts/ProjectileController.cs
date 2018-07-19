using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public float xspeed = 0f;
	public float yspeed = 0f;

	public int damageToGive;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position.x += xspeed;
		position.y += yspeed;
		transform.position = position;
		// I think this tells the projectile to stick its position coordinates to xspeed/yspeed float
		// I think this also tells the number value for the position to add the number once per frame of the value
		// of whatever xspeed/yspeed value is
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
		//If this collider hits anything under the Enemy tag, the Enemy's health goes down by amount

		Instantiate (impactEffect, transform.position, transform.rotation);
		//This will spawn impact particiles when collider hits enemy. Then destroy's projectile.
		Destroy (gameObject);
	}
}