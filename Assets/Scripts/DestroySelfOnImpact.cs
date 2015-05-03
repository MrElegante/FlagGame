using UnityEngine;
using System.Collections;

public class DestroySelfOnImpact : MonoBehaviour {
	
	public LayerMask LayerToDestroy;
	public int ImpactDamage = 1;
	
	void OnTriggerEnter(Collider other) {
		if ((LayerToDestroy.value & (1 << other.gameObject.layer)) > 0) {
			Health health = gameObject.GetComponent<Health>();
			if (health != null)
				health.TakeDamage(ImpactDamage);
			
			Destroy(gameObject);
		}
	}
}
