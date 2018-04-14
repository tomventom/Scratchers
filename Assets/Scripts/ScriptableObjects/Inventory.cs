using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject {

	public List<WeaponObject> weapons;

}
