using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Projectile
{
	[Serializable]
	public struct ProjectileSpec
	{

		public string Name;


		public Type pType;


		//public AnimationCurve pAc;


		//public Sprite[] fadeAnim;


		//public bool hasFade;


		//public Sprite[] muzzleFlash;


		public enum Type
		{

			Round
		}
	}
}