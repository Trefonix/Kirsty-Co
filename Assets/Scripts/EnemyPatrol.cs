using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed; //Gives the enemy movement speed
	public bool moveRight; //If its right or left

	public Transform wallCheck; //Checks an empty game object if enemy is hitting wall
	public float wallCheckRadius; //How big is the radius for checking the wall
	public LayerMask whatIsWall; //Telling which layer (Which is Grounds) what layer or object is the wall
	private bool hittingWall; //Tells if its hitting the wall

	private bool notAtEdge; //Checking if player is not on the edge of a platform to stop him going off the edge
	public Transform edgeCheck; //Checking to see if there is an edge

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		//I guess this is to give check if its either hitting the wall or off the edge. Giving it a bit of physics.

		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;
		// If hittingWall is true or not on edge is false then moveright is either false or true
		if (moveRight) 
		{
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			//This is the scale of the enemy flipping it right
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			// if moveRight is true then enemy will move to the right
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			//This is the scale of the enemy flipping it left
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			//If moveRight is false then enemy will move to the left
		}
	}
}
