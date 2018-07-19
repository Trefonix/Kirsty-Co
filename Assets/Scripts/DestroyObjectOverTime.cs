using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour {

	public float lifetime;
	// Makes a float for the game to an objects lifetime

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		lifetime -= Time.deltaTime;
		// Counts down lifetime float value
		if (lifetime < 0) 
		{
			Destroy (gameObject);
			// if Lifetime float at 0 then the object will be destroyed
		}
	}
}
