using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponDataHolder : ScriptableObject
{
	 public GameObject weaponPrefab;
	 public WeaponData weaponData;
}
