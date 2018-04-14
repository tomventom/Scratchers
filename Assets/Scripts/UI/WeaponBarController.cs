using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBarController : MonoBehaviour {

	public Inventory weaponInventory;
	public GameObject slotPrefab;

	private List<Image> slotImages;

	void Start () {
		slotImages = new List<Image>();
		for (int i = 0; i < 10; i++) {
			GameObject slot = Instantiate(slotPrefab);
			slot.transform.SetParent(this.transform);
			slotImages.Add(slot.transform.Find("WeaponSprite").GetComponent<Image>());
		}

		if (weaponInventory.weapons.Count > 0 && weaponInventory.weapons.Count <= 10) {
			for (int i = 0; i <= weaponInventory.weapons.Count-1; i++) {
				slotImages[i].sprite = weaponInventory.weapons[i].sprite;
				slotImages[i].color = Color.white;
				// slotImages[i].preserveAspect = true;
			}
		}
	}
}
