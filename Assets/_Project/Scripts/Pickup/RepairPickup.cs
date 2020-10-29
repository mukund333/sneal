using SnealUltra.Assets._Project.Scripts.Pickup;
using SnealUltra.Assets._Project.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RepairPickup : Pickup
{
	public PickupData thisPickup;

	public PlayerStats playerStats;
	public CurrentPlayerComponentData player;

	private void OnEnable()
	{
		InitPickup();
	}
	private void Awake()
	{
		playerStats = FindObjectOfType<PlayerStats>();
		player = playerStats.GetComponent<CurrentPlayerComponentData>();
	}

	private void InitPickup()
	{

		thisPickup = PickupDatabase.instance.GetPickupByName("Repair");
	}

	public override string GetPowerUpName()
	{

		return thisPickup.Name;
	}
	public void SetPowerUpPoolId(int poolid)
	{

		thisPickup.poolId = poolid;
	}

	public override int GetPoolId()
	{
		return thisPickup.poolId;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{

		if (col.CompareTag("Player"))
		{
			playerStats.curHealth = 100;
			gameObject.SetActive(false);
		}
	}

	public override Vector2 GetSpawnFreqRange()
	{
		return thisPickup.spawnFreqRange;
	}

	public override int GetSpawnStartTime()
	{
		return thisPickup.spawnStartTime;
	}

	public override AnimationCurve GetCurve()
	{
		return thisPickup.curve;
	}

	public override int GetMaxFreq()
	{
		return thisPickup.timeToMaxSpawnFreq;
	}

}
