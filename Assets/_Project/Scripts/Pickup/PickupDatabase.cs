using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	public class PickupDatabase : MonoBehaviour
	{

		
		[SerializeField] PickupData[] pickups;
		[SerializeField] WeaponPick[] wepData;
		


		//public Sprite[] weaponTypeSprites;


		private static PickupDatabase _instance;
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


		public PickupData GetPickupRandom()
		{
			PickupData result = pickups[UnityEngine.Random.Range(0, pickups.Length)];
			result.wepData = wepData[UnityEngine.Random.Range(0, wepData.Length)];
			return result;
		}


	}
}