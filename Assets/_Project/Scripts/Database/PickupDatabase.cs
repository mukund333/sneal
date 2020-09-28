using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	public class PickupDatabase : MonoBehaviour
	{

		
		[SerializeField] PickupData[] pickups;
		
		


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
			
			return result;
		}

		public PickupData GetPickupByName(string pickupName)
		{
			PickupData result = default;
			for (int i=0; i<pickups.Length;i++)
			{
				if(pickups[i].Name==pickupName)
				{
					 result = pickups[i];
				}
				
				
			}

			return result;
		}


	}
}