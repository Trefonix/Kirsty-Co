using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {

	public int damageToGive; //Value of player's damage to enemy



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
			other.GetComponent<EnemyHealthManager> ().giveDamage(damageToGive);
		//If this script hits enemy then enemy takes damage
	}
}
