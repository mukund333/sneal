using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Weapon
{
	[Serializable]
	public struct WeaponStruct
	{
		public enum Type
		{

			Pistol,

			Rifle,

			ShotGun,

			MachineGun

			//LaserGun,

			//RocketLauncher,

			//GrenadeLauncher
		}

		[Header("Weapon Attributes")]
		public string Name;

		public Type wepType;

		public int spread;

		public int projIndex;

		public int shots;

		public float angle;

		[Header("Player Settings")]

		public float thrust;

		public float drag;

		public float lastShotTime;




		//public float fireRate;

		//public int projDistance;


		//public float projDistanceVariation;


		//public float projSpeed;


		//public float shake;


		//public int damage;




		//[Header("Submarine Movement")]
		//public AnimationCurve accCurve;


		//public float maxSpeed;


		//public float accTime;


		//public float acc;


		//[Header("Sfx")]
		//public bool hasSfx;


		//public float sfxRate;



	}
}