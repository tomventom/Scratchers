using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	Rigidbody2D rb;
	BoxCollider2D col;
	private float speed = 30f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
		CollisionCheck();
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
	
	// private void OnTriggerEnter2D(Collider2D other) {
	// 	if (other.transform.CompareTag(Constants.GroundTag)) {
	// 		Destroy(this.gameObject);
	// 	}
	// }

	private void CollisionCheck () {
		Vector2 moveDirection = (Vector2.right * 2f) * Time.deltaTime;

		Vector2 bottomRight = new Vector2 (col.bounds.max.x, col.bounds.min.y);
		Vector2 topLeft = new Vector2 (col.bounds.min.x, col.bounds.max.y);

		bottomRight += moveDirection;
		topLeft += moveDirection;

		if (Physics2D.OverlapArea (topLeft, bottomRight, 1 << LayerMask.NameToLayer (Constants.GroundLayer))) {
			Destroy(this.gameObject);
		}
	}

}
