using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	[Serializable]
	public struct Pickups
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
}