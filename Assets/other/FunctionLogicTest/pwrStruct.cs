using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct pwrStruct 
{
	public Vector2 spawnFreqRange;

	public int spawnStartTime;

	public int timeToMaxSpawnFreq;

	public AnimationCurve curve;
}
