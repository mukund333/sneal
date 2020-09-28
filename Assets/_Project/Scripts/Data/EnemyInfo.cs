using System;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{
	[Serializable]
	public struct EnemyInfo
	{

		public string Name;


		public int spawnStartTime;


		public Vector2 spawnFreqRange;


		public int timeToMaxSpawnFreq;


		public AnimationCurve curve;


		public float debug;


		public int poolId;
	}
}