using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int AmmoMax = 10;
	public int CurrentTotalAmmo;
	public int CurrentClipAmmo;
	public int ClipSize;
	public Transform OutOfAmmoIndicator;
	public Transform TimeToReloadInidcator;
	public Transform ReloadingIndicator;

	public bool HasEnoughTotalAmmo (int ammoCost) {
		if (CurrentTotalAmmo >= ammoCost)
			return true;
		else {
			OutOfAmmo();
			return false;
		}
	}

	public bool HasEnoughClipAmmo (int ammoCost, int ammoInClip) {
		if (ammoInClip >= ammoCost)
			return true;
		else {
			NeedToReload ();
			return false;
		}
	}

	//Take in a change to Ammo (AmmoChange) and apply the change. Note all changes are in positive numbes. If we're subtracting ammo, that must come in as a negative int.
	public void ChangeAmmoOnFire (Weapon weaponToChangeAmmo) {
		CurrentTotalAmmo = Mathf.Clamp (CurrentTotalAmmo - weaponToChangeAmmo.AmmoCost, 0, AmmoMax);
		CurrentClipAmmo = Mathf.Clamp (CurrentClipAmmo - weaponToChangeAmmo.AmmoCost, 0, weaponToChangeAmmo.ClipSize);
		weaponToChangeAmmo.AmmoInClip = Mathf.Clamp (weaponToChangeAmmo.AmmoInClip - weaponToChangeAmmo.AmmoCost, 0, weaponToChangeAmmo.ClipSize);
	}

	public void ChangeAmmoOnPickup (int AmmoChange) {
		CurrentTotalAmmo = Mathf.Clamp (CurrentTotalAmmo + AmmoChange, 0, AmmoMax);
	}

	public void NeedToReload(){
		Instantiate (TimeToReloadInidcator, transform.position, transform.rotation);
	}
	
	public void OutOfAmmo(){
		Instantiate (OutOfAmmoIndicator, transform.position, transform.rotation);
	}

	public void Reload(Weapon weaponToReload){
		Instantiate (ReloadingIndicator, transform.position, transform.rotation);
		weaponToReload.AmmoInClip = Mathf.Clamp (weaponToReload.AmmoInClip + CurrentTotalAmmo, 0, weaponToReload.ClipSize);
	}

	// Objects with ammo start with max ammo
	void Start () {
		CurrentTotalAmmo = AmmoMax;
	}
}
