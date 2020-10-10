using SnealUltra.Assets._Project.Scripts.Pickup;
using SnealUltra.Assets._Project.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InvincibilityPickup : MonoBehaviour
{
    public PickupData thisPickup;

	public PlayerStats playerStats;
	public CurrentPlayerComponentData player;

	private void Awake()
	{
		playerStats = FindObjectOfType<PlayerStats>();
		player = playerStats.GetComponent<CurrentPlayerComponentData>();
	}

	private void OnEnable()
	{
		InitPickup();
	}

	private void InitPickup()
	{
		
		thisPickup = PickupDatabase.instance.GetPickupByName("Invincibility");
	}


	public string GetPowerUpName()
	{
		
		return thisPickup.Name;
	}
	public void SetPowerUpPoolId(int poolid)
	{
		
		thisPickup.poolId = poolid;
	}

	public int GetPoolId()
	{
		return thisPickup.poolId;
	}

	public Vector2 GetSpawnFreqRange()
	{
		return thisPickup.spawnFreqRange;
	}

	public int GetSpawnStartTime()
	{
		return thisPickup.spawnStartTime;
	}

	public AnimationCurve GetCurve()
	{
		return thisPickup.curve;
	}

	public int GetMaxFreq()
	{
		return thisPickup.timeToMaxSpawnFreq;
	}

}
