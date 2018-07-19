using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullSteveAI : MonoBehaviour {


	public float speed;
	//This is how far BullSteve moves

	private Animator anim;
	// Links with the Animator tab in Unity
	private bool chargeup;
	private bool idle;
	private bool chargedown;
	private bool run;
	// Animation bools for Animator to work

	public bool runright = false;
	public bool runleft = false;
	// Bools for Bull Steve to run right or left

	// Use this for initialization
	void Start () {
		StartCoroutine (IdleTimeLeft());
		// Starts IdleTimeLeft function for timer
		anim = GetComponent <Animator> ();
		//Links with Animator Component in Unity
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool ("ChargeUp", chargeup);
		anim.SetBool ("Idle", idle);
		anim.SetBool ("ChargeDown", chargedown);
		anim.SetBool ("Run", run);
		if (runright == true) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}
		// If RunRight bool is true, then constantly BullSteve will go right.
		if (runleft == true) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}
		// Same for left
	}

	IEnumerator IdleTimeLeft(){
		idle = true;
		chargeup = false;
		chargedown = false;
		run = false;
		// Animation bools
		yield return new WaitForSeconds (5f);
		// Times for how many seconds
		StartCoroutine (DownchargeLeft ());
		//Start next Coroutine
	}
	IEnumerator DownchargeLeft(){
		idle = false;
		chargeup = false;
		chargedown = true;
		run = false;
		yield return new WaitForSeconds (0.6f);
		StartCoroutine (BullrunLeft ());
	}
	IEnumerator BullrunLeft(){
		idle = false;
		chargeup = false;
		chargedown = false;
		run = true;
		runleft = true;
		// Running Left is true
		yield return new WaitForSeconds (2.2f);
		StartCoroutine (UpchargeLeft ());
	}
	IEnumerator UpchargeLeft(){
		idle = false;
		chargeup = true;
		chargedown = false;
		run = false;
		runleft = false;
		yield return new WaitForSeconds (0.6f);
		StartCoroutine (IdleTimeRight ());
		transform.localScale = new Vector3 (-11.02027f, 11.02027f, 0f);
		// Flips BullSteve to go Right
	}
	IEnumerator IdleTimeRight(){
		idle = true;
		chargeup = false;
		chargedown = false;
		run = false;
		yield return new WaitForSeconds (5f);
		StartCoroutine (DownchargeRight ());
	}
	IEnumerator DownchargeRight(){
		idle = false;
		chargeup = false;
		chargedown = true;
		run = false;
		yield return new WaitForSeconds (0.6f);
		StartCoroutine (BullrunRight ());
	}
	IEnumerator BullrunRight(){
		idle = false;
		chargeup = false;
		chargedown = false;
		run = true;
		runright = true;
		// Running Right is true
		yield return new WaitForSeconds (2.2f);
		StartCoroutine (UpchargeRight ());
	}
	IEnumerator UpchargeRight(){
		idle = false;
		chargeup = true;
		chargedown = false;
		run = false;
		runright = false;
		yield return new WaitForSeconds (0.6f);
		StartCoroutine (IdleTimeLeft ());
		transform.localScale = new Vector3 (11.02027f, 11.02027f, 0f);
		//Flips BullSteve to go Left
	}
}

