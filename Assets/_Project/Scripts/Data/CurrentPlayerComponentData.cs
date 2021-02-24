﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CurrentPlayerComponentData : MonoBehaviour
{
	
	//public string weaponName;
	
	public int weaponNumber;
	public bool isEquipDirect = false;
	public bool isPassWeapon = false;
	public bool isPowerGun = false;
	public RecoilData recoilData;
	public PlayerTransformData playerTransformData;
	public WeaponDB weaponDB;
	WeaponDataHolder weaponDataHolder;
	[SerializeField] ProjectileDatabase projectileDatabase; 

	int previusGeneralWeapon;
	
	private float waitTime;

	private void Awake()
	{
		weaponDB = FindObjectOfType<WeaponDB>();
		projectileDatabase = FindObjectOfType<ProjectileDatabase>();
		//GenerateWeaponByName();
		//AutoGeratedWeapon();
		GenerateWeaponByType();

		previusGeneralWeapon = weaponNumber;// temp assignment

	}

	private void Update()
	{
		if(isEquipDirect==true)
		{
			AutoGeratedWeapon();
			SetBulletData();
			isEquipDirect = false;
			isPassWeapon = true;
		}

		if(isPowerGun == true)
		{
			startPowerGun();
			isPowerGun = false;
		}

		


	}

	void startPowerGun()
	{
		StartCoroutine(TimerCoroutine());
	}

	public void SetRigidBodyData(float forceVelocity)
	  {
		 recoilData.rigidbodyData = forceVelocity;  
		
	  }
	  
	  public void SetPlayerPosition(Vector3 playerPosition, Vector3 playerShootPoint)
	  {
         playerTransformData.playerPosition = playerPosition;
		playerTransformData.playerShootPoint = playerShootPoint;
	  }
	  
	  public void SetPlayerRotation(Quaternion playerRotation)
	  {
         playerTransformData.playerRotation = playerRotation;
	  } 
	  
	  public bool GetIsRecoilingComplete()
	  {
		  return recoilData.isRecoilingComplete;
	  }
	  public void AutoGeratedWeapon()
	  {
		
		weaponDataHolder = weaponDB.GenerateWeaponByType(weaponNumber);
		
	  }


	//public void GenerateWeaponByName(string wepName)
	//{
	//	weaponDataHolder = weaponDB.GenerateWeaponByName(wepName);
	//}



	//public void GenerateWeaponByName()
	//{
	//	 weaponDataHolder = weaponDB.GenerateWeaponByName(weaponName);	
	//}
	public GameObject GetWeaponByName()
	{
		return weaponDataHolder.weaponPrefab;
	}

	public WeaponData GetWeaponDataByName()
	{
		return weaponDataHolder.weaponData;
	}

	public void GenerateWeaponByType()
	{
		weaponDataHolder = weaponDB.GenerateWeaponByType(weaponNumber);
	}
	
	IEnumerator TimerCoroutine()
	{
		//float elapsedTime = 0;

		//while (elapsedTime <= waitTime)
		//{
		//	elapsedTime += Time.deltaTime;
		//	yield return null;
		//}

		yield return new WaitForSeconds(5f);
		weaponNumber = previusGeneralWeapon;
		isEquipDirect = true;
		
	}

	public void SetBulletData()
	{
		
			projectileDatabase.isWeaponChange = false;
		
		
	}


}
