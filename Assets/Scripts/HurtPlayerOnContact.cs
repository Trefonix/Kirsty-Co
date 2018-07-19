using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive; //Value to enemies damage to player

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			HealthManager.HurtPlayer (damageToGive);
			//if player hits enemy then damage is given to the player via Health Manager script HurtPlayer function
			var player = other.GetComponent<PlayerController> (); //calls playerController script
			player.knockbackCount = player.knockbackLength; //Suppose to give knockback to player

			if (other.transform.position.x < transform.position.x)
				player.knockFromRight = true;
		    //If on the right and hit, Knockback on the player is true, else if on the left is false
			else
				player.knockFromRight = false;
		}
	}
}
