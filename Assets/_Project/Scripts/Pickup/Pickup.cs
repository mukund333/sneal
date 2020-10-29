using System.Collections;
using System.Collections.Generic;
using SnealUltra.Assets._Project.Scripts.Player;
using SnealUltra.Assets._Project.Scripts.Pickup;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{

	public abstract string GetPowerUpName();



	public abstract int GetPoolId();


	public abstract Vector2 GetSpawnFreqRange();

	public abstract int GetSpawnStartTime();


	public abstract AnimationCurve GetCurve();


	public abstract int GetMaxFreq();
	
}
