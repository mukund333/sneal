using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDB : MonoBehaviour
{
    
     public List<GameObject> weaponList;
	
     public List<WeaponData> weaponDataList;

	 public WeaponDataHolder defaultGun ;

	 public WeaponDataHolder autoGenarateGun;







	private void Start()
	{
		//GenerateWeapon();
	}
	//public void GenerateWeapon()
	//{
		
	//	GenerateWeaponByType(i);
	//}

	public WeaponDataHolder GenerateWeaponByType()
	{
		int i;
		i = UnityEngine.Random.Range(0, weaponList.Count);

		autoGenarateGun.weaponPrefab = GetWeaponByType(i);
		Debug.Log("" + autoGenarateGun.weaponPrefab);
		autoGenarateGun.weaponData = GetWeaponDataByType(i);
		Debug.Log("" + autoGenarateGun.weaponData);
		return autoGenarateGun;
	}

	public GameObject GetWeaponByType(int i)
	{

		return weaponList[i];
	}

	public WeaponData GetWeaponDataByType(int i)
	{
		  
		return weaponDataList[i];
	}

	public WeaponDataHolder GenerateWeaponByName(string GunName)
	{
		defaultGun.weaponPrefab = GetWeaponByName(GunName);
		defaultGun.weaponData   =	GetWeaponDataByName(GunName);
	
		return defaultGun;
	}
	public GameObject GetWeaponByName(string GunName)
	{

		foreach (GameObject wep in weaponList)
		{
			if (wep.name == GunName)
			{
				return wep;
			}
		}
		return weaponList[0];
		
	}

	public WeaponData GetWeaponDataByName(string GunName)
	{
		foreach (WeaponData wep in weaponDataList)
		{
			if (wep.weaponName == GunName)
			{
				
				return wep;
			}
		}
		return weaponDataList[0];
	}


}
