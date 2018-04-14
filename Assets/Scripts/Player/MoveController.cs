using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class MoveController : MonoBehaviour {

	private Rigidbody2D rb;
	private BoxCollider2D col;
	private SpriteRenderer sr;
	private Animator anim;
	private GroundCheck groundCheck;

	private bool jump;
	private bool isGrounded;
	private bool isWalking;
	private bool goingLeft;

	private float walkSpeed = 5f;
	private float jumpSpeed = 15f;

	private float xInput;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<BoxCollider2D> ();
		sr = transform.Find ("PlayerSprite").GetComponent<SpriteRenderer> ();
		anim = transform.Find ("PlayerSprite").GetComponent<Animator> ();
		groundCheck = transform.Find ("GroundCollider").GetComponent<GroundCheck> ();
	}

	void Update () {
		isGrounded = groundCheck.Grounded;
		isWalking = (isGrounded && xInput != 0);
		sr.flipX = goingLeft;

		ManageAnims ();
	}

	void FixedUpdate () {
		if (jump) {
			jump = false;
			rb.AddForce (new Vector2 (0f, jumpSpeed), ForceMode2D.Impulse);
		}
		rb.velocity = new Vector2 (xInput * walkSpeed, rb.velocity.y);

		FinalCollisionCheck ();
	}

	public void GoingLeft (bool value) {
		goingLeft = value;
	}

	public void Jump () {
		if (isGrounded)
			jump = true;
	}

	public void SetHorizontalInput (float input) {
		xInput = input;
	}

	private void ManageAnims () {
		anim.SetBool (Constants.AnimationWalking, isWalking);
		anim.SetBool (Constants.AnimationJumping, !isGrounded);
	}

	private void FinalCollisionCheck () {
		Vector2 moveDirection = new Vector2 ((rb.velocity.x * Time.fixedDeltaTime) / 2f, 0.2f);

		Vector2 bottomRight = new Vector2 (col.bounds.max.x, col.bounds.min.y);
		Vector2 topLeft = new Vector2 (col.bounds.min.x, col.bounds.max.y);

		bottomRight += moveDirection;
		topLeft += moveDirection;

		if (Physics2D.OverlapArea (topLeft, bottomRight, 1 << LayerMask.NameToLayer (Constants.GroundLayer))) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
	}

}