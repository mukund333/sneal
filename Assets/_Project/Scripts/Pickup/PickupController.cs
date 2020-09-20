using SnealUltra.Assets._Project.Scripts.Player;
using SnealUltra.Assets._Project.Scripts.Weapon;

using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	[RequireComponent(typeof(Collider2D))]
	public class PickupController : MonoBehaviour
	{
		[SerializeField]
		string weaponPickName;

		public PickupData thisPickup;
		public WeaponData weapon;

		private PickupBoost pickupBoost;
		private delegate void PickupBoost();

		public bool WeaponBool = false;
		private SpriteRenderer wepSpriteRend;

		public PlayerStats playerStats;
		public CurrentPlayerComponentData player;

		public event Action OnAutoGenWeapon;





		private void Awake()
		{

			
			playerStats = FindObjectOfType<PlayerStats>();
			player = playerStats.GetComponent<CurrentPlayerComponentData>();
			weaponPickName = player.weaponName;
		

		}


		private void OnEnable()
		{
			InitPickup();
		}


		private void InitPickup()
		{
			thisPickup = PickupDatabase.instance.GetPickupRandom();

			switch (thisPickup.pickupType)
			{
				case PickupData.PickupType.Repair:
					pickupBoost = new PickupBoost(Repair);
					break;

				case PickupData.PickupType.Invincibility:
					pickupBoost = new PickupBoost(Invincibility);
					break;

				case PickupData.PickupType.Speed:
					pickupBoost = new PickupBoost(Speed);
					break;

				case PickupData.PickupType.Weapon:
					pickupBoost = new PickupBoost(WeaponPick);
					WeaponBool = true;
					break;

			}
		}


		private void OnTriggerEnter2D(Collider2D col)
		{
			
			if (col.CompareTag("Player"))
			{
				pickupBoost();
			
				if (WeaponBool == true)
				{
					player.isEquipDirect = true;
				}
				gameObject.SetActive(false);
			}
		}


		private void Repair()
		{
			playerStats.Repair();
		}

		private void Invincibility()
		{
			playerStats.Invincibility();
		}

		private void Speed()
		{
			playerStats.Speed();
		}

		private void WeaponPick()
		{

			
		}



	}
}