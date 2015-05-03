using UnityEngine;
using System.Collections;

public class WeaponSlot : MonoBehaviour {

	public Transform AttachPoint;
	public KeyCode FireKey = KeyCode.Space;
	public KeyCode ReloadKey = KeyCode.R;
	public KeyCode DropKey = KeyCode.B;


	public bool IsSlotFull(){
		if (attachedWeapon != null)
			return true;
		else
			return false;
	}

	private Weapon attachedWeapon;
	private float nextFire = 0.0F;
	private float nextReload = 0.0F;

	
	public bool TryAttach (Weapon weapon){
		if (IsSlotFull()) {
			return false;
		}
		attachedWeapon = weapon;
		weapon.transform.parent = AttachPoint;
		weapon.transform.localPosition = Vector3.zero;
		weapon.transform.localRotation = Quaternion.identity;
		return true;
		
	}

	private void UnAttach(){
		if (attachedWeapon != null) {
			attachedWeapon.IsPickedUp = false;
			attachedWeapon.transform.parent = null;
			attachedWeapon = null;
		}
	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ammo ammo = gameObject.GetComponent<Ammo> ();
		//When the space button is pressed, fires a bullet if the gun has ammo and fire rate has passed
		if ((ammo.HasEnoughTotalAmmo (attachedWeapon.AmmoCost) == true)) {	
			if (((Input.GetKey (FireKey)) && (Time.time > nextFire)) && (ammo.HasEnoughClipAmmo (attachedWeapon.AmmoCost, attachedWeapon.AmmoInClip) == true)) {
				//Limits the number of bullets fired to the weapon-defined fire rate
				nextFire = Time.time + attachedWeapon.FireRate;
				//When the fire rate is up, shoots a new projectile
				Instantiate (attachedWeapon.Projectile, attachedWeapon.FirePoint.position, attachedWeapon.FirePoint.rotation);
				//Subtracts the bullet shot from current ammo level
				ammo.ChangeAmmoOnFire (attachedWeapon);
				}
		}
		if ((Input.GetKey (ReloadKey)) && (Time.time > nextReload)) {
			nextReload = Time.time + attachedWeapon.ReloadRate;
			ammo.Reload(attachedWeapon);
		}
		if (Input.GetKey(DropKey)) {
			UnAttach();
		}
	}
}

