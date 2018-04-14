using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Shoot Component", menuName = "Items/Components/Shoot Component")]
public class ShootComponent : BaseComponent {

	public GameObject projectilePrefab;

	public void Shoot (Vector2 origin, Quaternion rotation) {
		Instantiate (projectilePrefab, origin, rotation);
	}

}