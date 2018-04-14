using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Inventory weaponInventory;
	private Transform weaponTransform;
	private Transform weaponHolder;
	private Vector2 bounds;
	private int index;

	void Start () {
		weaponHolder = transform.Find ("WeaponHolder");
		weaponTransform = weaponHolder.Find ("WeaponTransform");
		if (!weaponInventory.weapons.Count.Equals (0)) {
			Equip (weaponInventory.weapons[0], 0);
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Shoot ();
		}
	}

	private void Shoot () {
		ShootComponent shootComponent = (ShootComponent) weaponInventory.weapons[index].components.Find (BaseComponent => BaseComponent.GetType () == typeof (ShootComponent));
		if (shootComponent != null) {
			Vector3 barrelPosition = weaponInventory.weapons[index].barrelPosition;
			Vector3 projectilePosition = weaponHolder.TransformPoint(barrelPosition);
			shootComponent.Shoot (projectilePosition, weaponTransform.rotation);
		}
	}

	private void Equip (WeaponObject weapon, int i) {
		if (weaponTransform == null) return;
		index = i;
		weaponTransform.localPosition = weapon.position;
		weaponTransform.GetComponent<SpriteRenderer> ().sprite = weapon.sprite;
		weaponHolder.GetComponent<WeaponRotation>().UpdateWeaponPosition(weaponInventory.weapons[index].barrelPosition);
	}

	public void CycleWeapons (int i) {
		if (weaponInventory.weapons.Count > 1) {
			int newIndex = index + i;
			if (i == 1) {
				if (newIndex < weaponInventory.weapons.Count) {
					Equip (weaponInventory.weapons[newIndex], newIndex);
				} else {
					Equip (weaponInventory.weapons[0], 0);
				}
			} else {
				if (newIndex > -1) {
					Equip (weaponInventory.weapons[newIndex], newIndex);
				} else {
					Equip (weaponInventory.weapons[weaponInventory.weapons.Count - 1], weaponInventory.weapons.Count - 1);
				}
			}
		}
	}
}