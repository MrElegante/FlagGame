using UnityEngine;
using System.Collections;

public class ChangeAmmoOnImpact: MonoBehaviour {

	public LayerMask LayerToChangeAmmo;
	public int AmmoChange = 30;

	void OnTriggerEnter(Collider other) {
		if ((LayerToChangeAmmo.value & (1 << other.gameObject.layer)) > 0) {
				Ammo ammo = other.gameObject.GetComponent<Ammo>();
				if (ammo != null)
					ammo.ChangeAmmoOnPickup(AmmoChange);
		}
	}
}
