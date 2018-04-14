using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public bool Grounded;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.CompareTag(Constants.GroundTag)) {
			Grounded = true;
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.transform.CompareTag(Constants.GroundTag)) {
			Grounded = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.transform.CompareTag(Constants.GroundTag)) {
			Grounded = false;
		}
	}
}
