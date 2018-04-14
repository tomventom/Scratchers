using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	private MoveController moveController;
	private WeaponController weaponController;

	void Start () {
		moveController = GetComponent<MoveController>();
		weaponController = GetComponent<WeaponController>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump"))
			moveController.Jump();
		moveController.SetHorizontalInput(Input.GetAxisRaw("Horizontal"));
		WeaponWheel();
	}

	private void WeaponWheel() {
		if (weaponController == null) return;
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			weaponController.CycleWeapons(1);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			weaponController.CycleWeapons(-1);
		}
	}
}
