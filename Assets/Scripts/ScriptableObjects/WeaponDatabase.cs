using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Weapon Database", menuName = "Items/Weapon Database")]
public class WeaponDatabase : ScriptableObject {

	[Expandable]
	public List<WeaponObject> weapons = new List<WeaponObject>();

}
