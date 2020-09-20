using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SnealUltra.Assets._Project.Scripts.Weapon
{
	public class WeaponDatabase : MonoBehaviour
	{
		/*
		  ---------------machine gun-------------------------------

		   thrust = 25       drag = 50          lastShotTime = 0.3

		  ----------------shotgun----------------------------------

		   thrust = 50       drag = 3           lastShotTime = 1  spread =20 t0 30 editor

		 */

		private static WeaponDatabase _instance;

		public WeaponStruct[] weapons;



		private int typeLength;

		public static WeaponDatabase instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<WeaponDatabase>();
				}
				return _instance;
			}
		}

		private void Awake()
		{
			typeLength = Enum.GetValues(typeof(WeaponStruct.Type)).Length;
		}

		public WeaponStruct GetWeaponByName(string Name)
		{
			WeaponStruct result = weapons[0];
			for (int i = 0; i < weapons.Length; i++)
			{
				if (weapons[i].Name == Name)
				{
					result = weapons[i];
					break;
				}
			}
			return result;
		}

		public WeaponStruct GetWeaponByIndex(int index)
		{
			WeaponStruct result = weapons[0];
			for (int i = 0; i < weapons.Length; i++)
			{
				if (i == index)
				{
					result = weapons[i];
					break;
				}
			}
			return result;
		}

		public WeaponStruct GenerateWeapon()
		{
			WeaponStruct result = default;

			result.wepType = (WeaponStruct.Type)UnityEngine.Random.Range(0, 3);

			WeaponStruct.Type wepType = result.wepType;



			switch (wepType)
			{
				case WeaponStruct.Type.Pistol:

					result.projIndex = 0;
					result.thrust = 100f;
					result.drag = 10f;
					result.lastShotTime = 0.5f;

					break;

				case WeaponStruct.Type.Rifle:

					result.projIndex = 0;
					result.shots = UnityEngine.Random.Range(2, 2);
					result.angle = UnityEngine.Random.Range(5, 45);
					result.thrust = 25f;
					result.drag = 50f;
					result.lastShotTime = 0.3f;
					result.shots = 30;

					break;

				case WeaponStruct.Type.ShotGun:

					result.projIndex = 0;

					result.thrust = 50f;
					result.drag = 3f;
					result.lastShotTime = 1f;


					break;

				case WeaponStruct.Type.MachineGun:
					result.projIndex = 0;
					result.shots = UnityEngine.Random.Range(2, 2);
					result.angle = UnityEngine.Random.Range(13, 15);
					result.spread = UnityEngine.Random.Range(15, 25);
					result.thrust = 25f;
					result.drag = 50f;
					result.lastShotTime = 0.3f;
					result.shots = 30;
					break;


			}

			//if (wepType == Weapon.Type.Rifle)
			//{
			//	result.projIndex = 0;
			//	result.shots = UnityEngine.Random.Range(2, 2);
			//	result.angle = (float)UnityEngine.Random.Range(5, 45);
			//	result.thrust = 25f;
			//	result.drag = 50f;
			//	result.lastShotTime = 0.3f;

			//}
			//else if (wepType == Weapon.Type.ShotGun)
			//{
			//	result.projIndex = 0;

			//	result.thrust = 50f;
			//	result.drag = 3f;
			//	result.lastShotTime = 1f;
			//}else if(wepType == Weapon.Type.Pistol)
			//{
			//	result.projIndex = 0;

			//	result.thrust = 100f;
			//	result.drag = 10f;
			//	result.lastShotTime = 0.5f;
			//}


			result.Name = string.Empty + result.wepType.ToString() + UnityEngine.Random.Range(0, 7000);
			//result.spread = UnityEngine.Random.Range(15, 50);



			//	result.fireRate = UnityEngine.Random.Range(7f, 25f);

			//result.projDistance = UnityEngine.Random.Range(40, 150);
			//result.projDistanceVariation = UnityEngine.Random.Range(0f, (float)result.projDistance * 0.75f);
			//result.projSpeed = (float)UnityEngine.Random.Range(500, 750);
			//result.shake = UnityEngine.Random.Range(0.5f, 1f);
			//result.damage = UnityEngine.Random.Range(1, 2);
			//result.maxSpeed = (float)UnityEngine.Random.Range(128, 160);
			//result.accTime = UnityEngine.Random.Range(0.5f, 4f);
			////result.accCurve = CurveDatabase.instance.GetCurve(4);
			//result.hasSfx = true;
			//if (result.fireRate > 17f)
			//{
			//	result.sfxRate = 17f;
			//}
			//else
			//{
			//	result.sfxRate = result.fireRate;
			//}
			return result;
		}


	}
}