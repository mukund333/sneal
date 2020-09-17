using SnealUltra.Assets._Project.Scripts.Player;
using SnealUltra.Assets._Project.Scripts.Weapon;

using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	[RequireComponent(typeof(Collider2D))]
	public class PickupManager : MonoBehaviour
	{
		private PickupBoost pickupBoost;


		private Pickups thisPickup;

        WeaponStruct weapon;

		//private Weapon weapon;


		//private SpriteRenderer thisSpriteRend;

		public bool WeaponBool = false;
		private SpriteRenderer wepSpriteRend;


		private PlayerStats playerStats;


		private PlayerController player;


		private delegate void PickupBoost();

		private void Awake()
		{

			//this.thisSpriteRend = base.GetComponent<SpriteRenderer>();
			//this.wepSpriteRend = new GameObject().AddComponent<SpriteRenderer>();
			//this.wepSpriteRend.transform.position = this.thisSpriteRend.transform.position;
			//this.wepSpriteRend.transform.parent = base.transform;
			//this.wepSpriteRend.sortingLayerName = this.thisSpriteRend.sortingLayerName;
			//this.wepSpriteRend.sortingOrder = 1;

			playerStats = FindObjectOfType<PlayerStats>();
			player = playerStats.GetComponent<PlayerController>();

			weapon = player.currentWeapon;
			//Debug.Log("current weapon :" + weapon.wepType);

			//player = FindObjectOfType<Player>();
		}


		private void OnEnable()
		{
			InitPickup();
		}


		private void InitPickup()
		{
			thisPickup = PickupDatabase.instance.GetPickupRandom();




			//this.thisSpriteRend.sprite = this.thisPickup.sprite;
			//this.wepSpriteRend.sprite = PickupDatabase.instance.weaponTypeSprites[(int)weapon.wepType];

			switch (thisPickup.pickupType)
			{
				case Pickups.PickupType.Repair:
					pickupBoost = new PickupBoost(Repair);
					break;

				case Pickups.PickupType.Invincibility:
					pickupBoost = new PickupBoost(Invincibility);
					break;

				case Pickups.PickupType.Speed:
					pickupBoost = new PickupBoost(Speed);
					break;

				case Pickups.PickupType.Weapon:
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
					player.GetComponent<PlayerController>().EquipWeaponDirect(weapon);
					Debug.Log("assigning weapon :" + weapon.wepType);
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

			weapon = WeaponDatabase.instance.GenerateWeapon();
			player.currentWeapon = weapon;
			Debug.Log("generated weapon :" + weapon.wepType);
		}



	}
}