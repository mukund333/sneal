using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PickupData", menuName = "PickupData")]
public class PickupData : ScriptableObject
{
	public enum PickupType
	{

		Repair,

		Invincibility,

		Speed,

		Weapon


	}

	public string Name;


	public PickupType pickupType;


	//public Sprite sprite;


	public WeaponPick wepData;



}

