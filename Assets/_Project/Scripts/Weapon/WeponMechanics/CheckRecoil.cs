using SnealUltra.Assets._Project.Scripts.Mixins;
using SnealUltra.Assets._Project.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CheckRecoil : MixinBase
{
    public CurrentWeaponData recoilData;

    public bool isApplyingThrust = false;
    public bool isRecoiling;

    public override bool Check()
    {
        if (recoilData.GetRigidbodyData() < 0.5)
        {

            return isRecoiling = true;
        }

        return isRecoiling = false;
    }

    public override void Action()
    {
        isApplyingThrust = true;
        isRecoiling = true;

    }

    private void Update()
    {

        if (isRecoiling == true && isApplyingThrust == true)
        {
            //recoilData.isRecoilingComplete = true;
            recoilData.SetRecoil(true);
            isApplyingThrust = false;
        }

        if (recoilData.GetRigidbodyData() > 0.5)
        {
            //recoilData.isRecoilingComplete = false;//set data
            recoilData.SetRecoil(false);
            isRecoiling = false;
        }
        if (recoilData.GetRigidbodyData() < 0.5)
        {
            isRecoiling = true;
        }
    }
}