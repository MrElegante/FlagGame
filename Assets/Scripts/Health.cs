using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HealthMax = 10;
	int CurrentHealth;

	//Take in an int (damage) and deal that damage
	public void TakeDamage (int damage) {
		CurrentHealth = CurrentHealth - damage;
		//If health = 0, Object dies
		if (CurrentHealth <= 0)
			Destroy (gameObject);
	}
	// Objects with health start with max health
	void Start () {

	}
}


