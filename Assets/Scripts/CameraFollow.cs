// CameraFollow
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private MoveController player;
	private Collider2D playerCollider;

	private float verticalOffset = 1f;
	private float lookAheadDstX = 4f;
	private float lookSmoothTimeX = 1f;
	private float verticalSmoothTime = 0.4f;
	private Vector2 focusAreaSize = new Vector2(3f, 6f);

	private FocusArea focusArea;

	private float currentLookAheadX;
	private float targetLookAheadX;
	private float lookAheadDirX;
	private float smoothLookVelocityX;
	private float smoothVelocityY;

	void Start () {
		player = GameObject.Find (Constants.PlayerTag).GetComponent<MoveController> ();
		playerCollider = player.transform.GetComponent<Collider2D> ();
		focusArea = new FocusArea (playerCollider.bounds, focusAreaSize);
	}

	void LateUpdate () {
		focusArea.Update (playerCollider.bounds);

		Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;

		if (focusArea.velocity.x != 0) {
			lookAheadDirX = Mathf.Sign (focusArea.velocity.x);
				targetLookAheadX = lookAheadDirX * lookAheadDstX;
		}

		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

		focusPosition.y = Mathf.SmoothDamp (transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
		focusPosition += Vector2.right * currentLookAheadX;
		transform.position = (Vector3) focusPosition + Vector3.forward * -10;
	}

	// void OnDrawGizmos () {
	// 	Gizmos.color = new Color (1, 0, 0, .5f);
	// 	Gizmos.DrawCube (focusArea.centre, focusAreaSize);
	// }

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left, right;
		float top, bottom;

		public FocusArea (Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x / 2;
			right = targetBounds.center.x + size.x / 2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			centre = new Vector2 ((left + right) / 2, (top + bottom) / 2);
		}

		public void Update (Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2 ((left + right) / 2, (top + bottom) / 2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}