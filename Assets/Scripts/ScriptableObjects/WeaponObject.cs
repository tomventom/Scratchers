using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Weapon", menuName = "Items/Weapon")]
public class WeaponObject : ScriptableObject {

	public Vector2 position;
	public Vector2 barrelPosition;
	public Sprite sprite;
	public List<BaseComponent> components;
	
}
