using System.Collections;
using System;
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
	[SerializeField] GunPowerupUnlockData gunPowerupUnlockData;
	
    public PickupData thisPickup;
    
    public CurrentPlayerComponentData player;
	
	public float pickupLife;

	public WeaponDB weaponDB;

	public int powerupGunNumber;
	
	public int randomInt;
	
	

	
	public bool isWeaponChange = false;


	private void OnEnable()
    {
		gunPowerupUnlockData.LoadUnlockData();
		
		Configure();
		
		
        InitPickup();
		
		
		
    }
    private void Awake()
    {
		
        player = FindObjectOfType<CurrentPlayerComponentData>();
		weaponDB = FindObjectOfType<WeaponDB>();
		// range of powerup gun
		
		
		
		//powerupGunNumber = Random.Range(2, 3);
		
		
    }

    void Start()
    {
		Configure();
		 StartCoroutine(LateCall());
		
    }
	
	     IEnumerator LateCall()
     {
 
         yield return new WaitForSeconds(pickupLife);
 
         gameObject.SetActive(false);
         //Do Function here...
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
	
	
	#region Configure and Dispose
				private void Configure(){
					
							Debug.Log(gunPowerupUnlockData.itemList.Count);
							
							if(gunPowerupUnlockData.allUnlock){
								var random = new System.Random();
								
								powerupGunNumber = random.Next(gunPowerupUnlockData.itemList.Count);
								//powerupGunNumber = Random.Range(gunPowerupUnlockData.itemList[0],gunPowerupUnlockData.itemList.Count);
								//	powerupGunNumber = Random.Range(0,gunPowerupUnlockData.itemList.Count);		
							}else{
									powerupGunNumber = gunPowerupUnlockData.itemList[0];
							}
					
		
					
				}
				private void Dispose(){
					randomInt=0;
					powerupGunNumber=0;
				}
	#endregion
	
	private void OnDisable(){
					Dispose();
				}
	
	
	
}
