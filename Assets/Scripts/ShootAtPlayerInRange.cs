using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour {

	public float playerRange; //value of how far the enemy can see the player

	public GameObject enemyFire; // Locates the enemies projectile object

	public PlayerController player; //Links Player Controller script

	public Transform launchPoint; //Links an empty game Object for the enemy to fire from

	public float waitBetweenShots; //Delays the enemy's shots so its not constantly firing

	private float shotCounter; //Shot Delay Time value??


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		shotCounter = waitBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));

		shotCounter -= Time.deltaTime;

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0) {
			Instantiate (enemyFire, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}

		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0) {
			Instantiate (enemyFire, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}
	}
}
