using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour {

	private PlayerController thePlayer; //Find playerController script

	public float moveSpeed; //Gives movement speed to the flying enemy

	public float playerRange; //What range the enemy can detect the player

	public LayerMask playerLayer; //To find the player layer

	public bool playerInRange; //If the player is in range var

	public bool facingAway; //If the player is facing away of the enemy

	public bool followOnLookAway; //the flying enemy will follow the player if its looking away

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> (); //Finds the Player Controller Script
	}
	
	// Update is called once per frame
	void Update () {
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);
		//Gives it a detection of if the player is within range I guess
		if (!followOnLookAway) {
			
			if (playerInRange) {
				transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
				return;
				// ??????
			}
		}

		if ((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0) || (thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0)) {
			facingAway = true;
		} else {
			facingAway = false;
		}
		// This detects if the player is facing the flying enemy or not

		if (playerInRange && facingAway) {
			transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
		}
		// if the player is witin range and looking away, the flying enemy will move towards the player
	}

	void OnDrawGizmosSelected () {
		Gizmos.DrawSphere (transform.position, playerRange);
	}
	//Makes a detection hitbox
}
