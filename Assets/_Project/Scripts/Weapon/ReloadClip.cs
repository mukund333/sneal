using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReloadClip : MixinBase
{
    public FloatData clip;
    public CurrentWeaponData weaponDefination;
    public float intialClipSize;
  

    public float reloadtimer;
    float reloadtime;

    bool isReloading;

    private void Start()
    {
        intialClipSize = weaponDefination.GetShots();
    }

    public override bool Check()
    {
        return !isReloading;
    }

    public override void Action()
    {
        isReloading = true;
        reloadtime = 0.0f;
    }

    private void Update()
    {
        if(isReloading)
        {
            reloadtime += Time.deltaTime;

            if(reloadtime > reloadtimer)
            {
                clip.SetData(intialClipSize);
                isReloading = false;
            }
        }
    }
}
