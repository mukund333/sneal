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

	[SerializeField] float targetDistance;
	[SerializeField] int _powerupHealthToGive = 0;
	[SerializeField] int _powerupMaxHealthToGive = 10;


	public int MaxHealthPowerup
	{
		get
		{
			return _powerupMaxHealthToGive;
		}

		set
		{
			_powerupMaxHealthToGive = Mathf.Clamp(value, 0, 200);
		}
	}

	public int HealthPowerUp
	{
		get
		{
			return _powerupHealthToGive;
		}

		set
		{
			_powerupHealthToGive = Mathf.Clamp(value, 0, _powerupMaxHealthToGive);
		}
	}

	private void OnValidate()
	{
		HealthPowerUp = _powerupHealthToGive;
		MaxHealthPowerup = _powerupMaxHealthToGive;
	}

	private void OnEnable()
	{
		OnValidate();
		HealthPowerUp = MaxHealthPowerup;
		InitPickup();
	}
	private void Awake()
	{
		playerStats = FindObjectOfType<PlayerStats>();
		player = playerStats.GetComponent<CurrentPlayerComponentData>();
	}

    private void Update()
    {
		DisableReapair();
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
			playerStats.playerHealth.Health += HealthPowerUp;
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

	public void DisableReapair()
	{
		 targetDistance = Vector3.Distance(this.transform.position, player.transform.position);

		if (targetDistance > 20)
		{
			gameObject.SetActive(false);
		}
	}

}
