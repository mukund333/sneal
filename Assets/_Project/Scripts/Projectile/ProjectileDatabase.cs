using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Projectile
{
	[Serializable]
	public class ProjectileDatabase : MonoBehaviour
	{
		private static ProjectileDatabase _instance;


		public ProjectileSpec[] projectiles;

		public static ProjectileDatabase instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<ProjectileDatabase>();
				}
				return _instance;
			}
		}


		public ProjectileSpec GetProjectileByIndex(int index)
		{
			return projectiles[index];
		}



	}
}