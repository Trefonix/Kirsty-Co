using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying)
			return;

		Destroy (gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	//NOTE: Keep this for now as I dunno if we need it to function. I want to be able to add our own death graphics in.
}
