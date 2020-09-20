using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CurrentPlayerComponentData : MonoBehaviour
{
	
	public string weaponName;
	public bool isEquipDirect = false;
	public bool isPassWeaPon = false;
	public RecoilData recoilData;
	public PlayerTransformData playerTransformData;
	public WeaponDB weaponDB;
	WeaponDataHolder weaponDataHolder;

	


	private void Awake()
	{
		weaponDB = FindObjectOfType<WeaponDB>();

		GenerateWeaponByName();
		//AutoGeratedWeapon();
	}

	private void Update()
	{
		if(isEquipDirect==true)
		{
			AutoGeratedWeapon();
			isEquipDirect = false;
			isPassWeaPon = true;
		}
	}



	public void SetRigidBodyData(int forceVelocity)
	  {
		 recoilData.rigidbodyData = forceVelocity;  
		
	  }
	  
	  public void SetPlayerPosition(Vector3 playerPosition)
	  {
         playerTransformData.playerPosition = playerPosition;
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
		
		weaponDataHolder = weaponDB.GenerateWeaponByType();
		
	  }


	//public void GenerateWeaponByName(string wepName)
	//{
	//	weaponDataHolder = weaponDB.GenerateWeaponByName(wepName);
	//}
	public void GenerateWeaponByName()
	{
		 weaponDataHolder = weaponDB.GenerateWeaponByName(weaponName);	
	}
	public GameObject GetWeaponByName()
	{
		return weaponDataHolder.weaponPrefab;
	}

	public WeaponData GetWeaponDataByName()
	{
		return weaponDataHolder.weaponData;
	}





}
