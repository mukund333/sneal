using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;
using SnealUltra.Assets._Project.Scripts.Weapon;

public class CurrentWeaponData : MonoBehaviour
{
    public WeaponData weaponDefination;
    
    public RecoilData playerRecoilData;
    public PlayerTransformData transformData;

    #region Initializations
    private void Start()
    {
       
        //    if (!weaponDefination.setManually)
        //    {
        //        weaponDefination.thrust = 25f;
        //        weaponDefination.drag = 50f;
        //        weaponDefination.lastShotTime = 0.3f;
        //        weaponDefination.shots = 30;
        //        weaponDefination.spread = 5;
    }


        //}
        #endregion

        #region Reporters
    public float GetThrust()
    {
       
        return weaponDefination.thrust;
    }

    public float GetDrag()
    {
        return weaponDefination.drag;
    }

    public float GetLastShotTime()
    {
        return weaponDefination.lastShotTime;
    }

    public float GetShots()
    {
        return weaponDefination.shots;
    }

    public int GetSpread()
    {
        return weaponDefination.spread;
    }


   
    public bool GetIsRecoiling()
    {
        return playerRecoilData.isRecoilingComplete;
    }

    public int GetRigidbodyData()
    {
        return playerRecoilData.rigidbodyData;
    }
    #endregion

    public void SetRecoil(bool isRecoil)
    {
        playerRecoilData.SetRecoil(isRecoil);
    }

    public Vector3 GetPlayerPosition()
    {
        return transformData.playerPosition;
    }
    public Quaternion GetPlayerRotation()
    {
        return transformData.playerRotation;
    }

}

//public string WeaponName;

//public WeaponStruct currentWeapon;

//public bool isRecoiling;
//public float rigidbodyValue;//always reset to zero 
//public float thrust;
//public float drag;

//public GameObject player;
//public Transform shootPoint;
//public Transform sprite;

//private void OnEnable()
//{
//    if (player == null)
//    {
//        player = GameObject.FindGameObjectWithTag("Player");

//    }

//    shootPoint = player.transform.GetChild(0);
//    sprite = player.transform.GetChild(1);
//}

//public WeaponStruct GetData()
//{
//    return currentWeapon;
//}

//public void Awake()
//{
//    currentWeapon = WeaponDatabase.instance.GetWeaponByName(WeaponName);
//}