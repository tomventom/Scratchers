using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour {

	void Start () {
		Invoke ("DestroyObject", LifeTime);
	}

	void DestroyObject () {
		Destroy (gameObject);
	}

	public float LifeTime = 6f;
}