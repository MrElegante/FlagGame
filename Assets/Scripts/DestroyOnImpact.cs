using UnityEngine;
using System.Collections;

public class DestroyOnImpact : MonoBehaviour {

	public LayerMask LayerToDestroy;
	public int ImpactDamage = 1;

	//When This Object hits another object
	void OnTriggerEnter(Collider other) {
		// find out if that object is on the right layer
		if ((LayerToDestroy.value & (1 << other.gameObject.layer)) > 0) {
			// if it's on the right layer, find out if it takes damage
			Health health = other.gameObject.GetComponent<Health>();
			// if it takes damage, deal damage
			if (health != null)
				health.TakeDamage(ImpactDamage);

			//destroy self
			Destroy(gameObject);
		}
	}
}
