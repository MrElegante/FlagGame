using UnityEngine;
using System.Collections;

public class GunShot: MonoBehaviour {

	public float Speed=1;
	public Transform Bullet;
	public Transform FirePoint;
	public int AmmoCost = 1;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ammo ammo = gameObject.GetComponent<Ammo>();
		Weapon weapon = gameObject.GetComponent<Weapon>();
		//When the space button is pressed, fires a bullet if the gun has ammo and fire rate has passed
		if ((Input.GetKey(KeyCode.Space) && (Time.time > nextFire)) && (ammo.HasEnoughTotalAmmo(AmmoCost)==true)) {
			//Limits the number of bullets fired to the gun defined fire rate
			nextFire = Time.time + fireRate;
			//When the fire rate is up, shoots a new bullet
			Instantiate (Bullet, FirePoint.position, FirePoint.rotation);
			//Subjtracts the bullet shot from current ammo level
			ammo.ChangeAmmoOnPickup(-AmmoCost);
		}
	}
}
