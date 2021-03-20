using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public bool setManually = false;
    public bool saveDataOnClose = false;

    public enum Type
    {

        Pistol,

        Rifle,

        ShotGun,

        MachineGun,
		
		Sniper

        //LaserGun,

        //RocketLauncher,

        //GrenadeLauncher
    }


    [Header("Weapon Attributes")]

    public int WeaponNumber;

    public string weaponName;

    public Type wepType;
   
    public int spread;

    public int projIndex;

    public int shots;

    public float angle;

    [Header("Player Settings")]

    public float thrust;

    public float drag;

    public float lastShotTime;
    
    
}
