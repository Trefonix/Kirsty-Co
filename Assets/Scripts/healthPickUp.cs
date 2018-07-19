using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour {

	public int healthtoGive;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		HealthManager.HurtPlayer (-healthtoGive);

		Destroy (gameObject);

	}
}
