using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour {

	public LayerMask LayerToImpact;
	public float FireRate = 0.5F;
	public float ReloadRate = 0.5F;
	public int MaxAmmo;
	public int AmmoCost = 1;
	public int DefaultStartingAmmo; // With this property I can say the rocket launcher starts with 3 rockets, but can hold up to 6, or whatever
	public Transform FirePoint;
	public GameObject Projectile;
	public GameObject GunPrefab;
	public bool IsPickedUp;
	public int ClipSize;
	public int AmmoInClip;

	private WeaponSlot myWeaponSlot;


	void OnTriggerEnter(Collider other) {

		if (IsPickedUp) {
			return;
		}
		if ((LayerToImpact.value & (1 << other.gameObject.layer)) > 0) {
			myWeaponSlot = other.gameObject.GetComponent<WeaponSlot>();
			if (myWeaponSlot != null) {
				IsPickedUp = myWeaponSlot.TryAttach(this);
				}
		}
	}
	void Start () {
		AmmoInClip = ClipSize;
	}

}
