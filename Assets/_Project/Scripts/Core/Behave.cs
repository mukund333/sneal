using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Core
{
	public class Behave : MonoBehaviour
	{

		public static Vector3 RoundPosition(Vector3 pos)
		{
			return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
		}


		public static T Choose<T>(T a, T b, params T[] p)
		{
			int num = UnityEngine.Random.Range(0, p.Length + 2);
			if (num == 0)
			{
				return a;
			}
			if (num == 1)
			{
				return b;
			}
			return p[num - 2];
		}
	}
}