using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform; //Locates platform game Object

	public float moveSpeed; // Makes Speed for platform's movement

	public Transform currentPoint; //Makes Startingpoint

	public Transform[] points; //Creates an a array of points for platform to move to

	public int pointSelection; // Gives the value of how many points of the array the platform moves

	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
		// currentpoints is linked with the points and how many points
	}
	
	// Update is called once per frame
	void Update () {


		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		// Moves the plaform towards the array point


		if(platform.transform.position == currentPoint.position){
			pointSelection++;
			//links the plaform with the Currentpoint position

			if (pointSelection == points.Length) {
				pointSelection = 0;
				// if its run out of the length of points from the array then it goes back to 0 and goes back
			}

			currentPoint = points[pointSelection];
			// currentpoints is linked with the points and how many points
		}
	}
}
