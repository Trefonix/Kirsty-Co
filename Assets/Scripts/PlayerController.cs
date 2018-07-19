using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpHeight; //A variable to check Jump height

	public Transform groundCheck; //A variable to check if player hits ground
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private Rigidbody2D rigi; // An instance name for the rigidbody component
	public bool grounded; //

	public GameObject projectile; // To look for the projectile game object
	public Transform firepoint;	// A invisable object to tell where the player will shoot at the side
	public Transform firepointSideUp; // Same as above but Side Up
	public Transform firepointUp; //""
	public Transform firepointSideDown; //""
	public bool flipped; // A bool to tell if it has flipped and therefore need to change motion for shot to go other way
	public float moveVelocity; // Velocity of the player
	public float moveSpeed; // Speed of the player
	public bool dirKeys; //Tells us we are hitting Direction Keys for Left and Right
	public bool doubleJumped; //A bool to tell if a double jump can or cannot be done

	public bool shooting; // Bool for shooting Animation
	public bool shotDelay; //A variable to say if finished the shot or not
	public bool lookingUp; //Bool for shooting Animation for side up
	public bool lookingDown; //Bool for shooting Animation for down
	public float knockback; //Knockback how far
	public float knockbackCount; //Knockback Timer for how long they are knocked back for
	public float knockbackLength; //?????
	public bool knockFromRight; //If knocked back on Left or Right


	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		rigi = GetComponent <Rigidbody2D>();
		// calls a var for the Rigidbody2D component
		anim = GetComponent <Animator> ();
		//calls a var for the Animator component
		flipped = false;
		// Starts the code off left so no flipping at this stage
		shooting = false;
		// Tells Shooting Animation not to play yet
		shotDelay = false;
		// Is a bool to delay the shot so that it dosen't fire rapidly
		lookingUp = false;
		lookingDown = false;
	}

	// Update is called once per frame
	void Update () {
		if (grounded) {
			doubleJumped = false;
		}
		// Grounded is a bool that if on the ground then players double jump does not active

		Controls ();
		// Calls the Control function
		anim.SetBool ("Grounded", grounded);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		// Grounded basically means is it uses whatever game object is in groundCheck checks the position and radius
		//  and develops overlapping circle.Then whatever whatever whatIsGround is, the player when hit whatIsGround won't go through
		// the ground. A platform if you will so she won't constantly fall.
		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
		// This sets up a float in the Animator for Speed for animating our character
	}


	public void Controls() {
		moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
		// Sets an Axis for Key and Button Input and works with moving the character

		anim.SetBool ("Shooting", shooting);
		anim.SetBool ("LookingUp", lookingUp);
		anim.SetBool ("LookingDown", lookingDown);
		//Makes shooting bool connect with the Animation bool
		//other two are for animation as well

		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			//If knockbackCount = 0 then tell physics to give control to the player again
		} else {
			if (knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
			// I belive this means the value of the knockback it give the X and Y axis on player when hit
			if (!knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);
			// Same but for left side
			knockbackCount -= Time.deltaTime;
			// Counts down to knockback Count
		}
		//This is the knockback code

		if (Input.GetAxis ("Horizontal") > 0) {
			// If Key is hitting left
			flipped = false;
			// It won't flip
			dirKeys = true;
			//Tells us we are hitting Direction Keys for Left and Right
		}  else if (Input.GetAxis ("Horizontal") < 0) {
			flipped = true;
			//It has flipped and therefore need to change motion for shot to go other way
			dirKeys = true;
		}  else {
			dirKeys = false;
			// If no Direction Key is pressed then this bool is false
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			Jump ();
			// If Pressed Jump button and is on the ground then Jump function calls
		}
		if (Input.GetButtonDown ("Jump") && !doubleJumped && !grounded) {
			//rigi.velocity = new Vector2 (0, jumpHeight);
			Jump ();
			doubleJumped = true;
		} 
		if (Input.GetButton("Fire1")) {
			shooting = true;
		}  else {
			shooting = false;
		}
		// Tells Shooting Animation to play
	

		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  == 0 && !dirKeys && flipped && !shotDelay){
			StartCoroutine (ShootingSideLeftStill ());
			//Starts a Timer when pressed to start ShootingSideLeftStill Function
			shooting = true;
		}
		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  == 0 && !dirKeys && !flipped && !shotDelay){
			StartCoroutine (ShootingSideRightStill ());
			shooting = true;
		}
		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  == 0 && dirKeys && !flipped && !shotDelay){
			StartCoroutine (ShootingSideRightRun ());
			shooting = true;
		}
		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  == 0 && dirKeys && flipped && !shotDelay){
			StartCoroutine (ShootingSideLeftRun ());
			shooting = true;
		}
	
		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  > 0 && dirKeys && !flipped && !shotDelay){
			StartCoroutine (ShootingSideUpRightRun ());
			shooting = true;
		}
		if(Input.GetButton("Fire1") && Input.GetAxis("Vertical")  > 0 && dirKeys && flipped && !shotDelay){
			StartCoroutine (ShootingSideUpLeftRun ());
			shooting = true;
		}

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (8.675181f, 8.675181f, 0.4322656f);
		}  else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-8.675181f, 8.675181f, 0.4322656f);
		}
		// This flips the whole player over when either left or right depending on direction and velocity
	}

	IEnumerator ShootingSideRightRun()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepoint.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = 2f;
		// Only going to explain what this code does once. If Fire button pressed and no vertical button pressed and Direction
		//Keys are pressed and is not flipped then it calls what projectile its using to present on screen and where the firepoint
		// is and rotation. Then it calls a gobal component and gets the script off ProjectileController and uses its variable
		// telling the movement of the projectile to go (in this instance) right. For Diagonal shots, just add Y axis.
		//Shoots Right while running
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}

	IEnumerator ShootingSideLeftRun()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepoint.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = -2f;
		// Shoots Left while running
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}

	IEnumerator ShootingSideRightStill()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepoint.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = 2f;
		// Shoot Right with no movement while facing right
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}

	IEnumerator ShootingSideLeftStill()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepoint.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = -2f;
		// Shoot Left with no movement while facing left
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}

	IEnumerator ShootingSideUpRightRun()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepointSideUp.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = 2f;
		go.GetComponent<ProjectileController> ().yspeed = 2f;
		// Shoots Right and Up while Running
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}

	IEnumerator ShootingSideUpLeftRun()
	{
		GameObject go = (GameObject)Instantiate (projectile, firepointSideUp.position, Quaternion.identity);
		go.GetComponent<ProjectileController> ().xspeed = -2f;
		go.GetComponent<ProjectileController> ().yspeed = 2f;
		// Shoots Left and Up while Running
		shotDelay = true;
		yield return new WaitForSeconds (0.3f);
		shotDelay = false;
	}



	public void Jump()
	{
		rigi.velocity = new Vector2 (0, jumpHeight);
		// This tells us how high the player can jump depending on the value of jumpHeight. Must have 0 as this is x coordinate
	}
}
