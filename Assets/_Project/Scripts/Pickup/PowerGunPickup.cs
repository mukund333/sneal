using System.Collections;
using System.Collections.Generic;
using SnealUltra.Assets._Project.Scripts.Pickup;
using SnealUltra.Assets._Project.Scripts.Player;
using UnityEngine;


/*
	check weapon database ....range of powerup guns 
	powergun range?
*/


[RequireComponent(typeof(Collider2D))]
public class PowerGunPickup : Pickup
{
    public PickupData thisPickup;
    
    public CurrentPlayerComponentData player;

	public WeaponDB weaponDB;

	public int powerupGunNumber = 3;


	private void OnEnable()
    {
        InitPickup();
    }
    private void Awake()
    {
        player = FindObjectOfType<CurrentPlayerComponentData>();
		weaponDB = FindObjectOfType<WeaponDB>();
		// range of powerup gun
		powerupGunNumber = Random.Range(0, 3);
		//Debug.Log("powergun number"+powerupGunNumber);
		
    }

    void Start()
    {
		
		
    }

    void Update()
    {

    }

    private void InitPickup()
    {

        thisPickup = PickupDatabase.instance.GetPickupByName("PowerGun");
       
    }

	private void OnTriggerEnter2D(Collider2D col)
	{

		if (col.CompareTag("Player"))
		{
			player.weaponNumber = powerupGunNumber;
			player.isEquipDirect = true;
			player.isPowerGun = true;
			gameObject.SetActive(false);
		}
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
