using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	public class PickupDatabase : MonoBehaviour
	{

		private static PickupDatabase _instance;


		public Pickups[] pickups;


		//public Sprite[] weaponTypeSprites;


		public WeaponPick[] wepData;

		public static PickupDatabase instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<PickupDatabase>();
				}
				return _instance;
			}
		}


		public Pickups GetPickupRandom()
		{
			Pickups result = pickups[UnityEngine.Random.Range(0, pickups.Length)];
			result.wepData = wepData[1];//[UnityEngine.Random.Range(0, this.wepData.Length)];
			return result;
		}


	}
}