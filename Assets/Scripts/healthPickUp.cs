using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour {

	public int healthtoGive; // Gives a health to Give value

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		HealthManager.HurtPlayer (-healthtoGive);
		// If health pick up hits player then health is given back
		Destroy (gameObject);
		// Destroys the object once done
	}
}
