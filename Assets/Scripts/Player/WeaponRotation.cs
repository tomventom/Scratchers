// WeaponRotation
using UnityEngine;

public class WeaponRotation : MonoBehaviour {
	
	private MoveController moveController;
	
	private Vector3 mousePos;
	private Vector3 weaponPos;
	private Vector3 weaponDifference;
	private float angle;

	private void Start() {
		moveController = GetComponentInParent<MoveController>();
	}

	private void Update() {
		mousePos = Input.mousePosition;
		mousePos.z = -10f;
		weaponPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x -= weaponPos.x;
		mousePos.y -= weaponPos.y;
		if (Mathf.Sign(mousePos.x) == 1f) {
			moveController.GoingLeft(false);
			angle = Mathf.Atan2(mousePos.y, mousePos.x) * 57.29578f;
			transform.rotation = Quaternion.Euler(0f, 0f, angle);
		}
		if (Mathf.Sign(mousePos.x) == -1f) {
			moveController.GoingLeft(true);
			angle = Mathf.Atan2(mousePos.y, mousePos.x) * 57.29578f;
			transform.rotation = Quaternion.Euler(180f, 0f, -angle);
		}
	}
	
	public void UpdateWeaponPosition(Vector3 diff) {
		weaponDifference = diff;
	}
}
