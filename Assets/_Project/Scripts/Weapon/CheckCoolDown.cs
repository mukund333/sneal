using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class CheckCoolDown : MixinBase
{
    [SerializeField]
    public CurrentWeaponData weaponDefination;
    [SerializeField]
    float cooldownTimer=0.5f;
    float cooldownTime;
    [SerializeField]
    bool isCool = true;



     void Start()
    {
        cooldownTimer = weaponDefination.GetLastShotTime();
    }


    public override bool Check()
    {
        return isCool;     
    }

    public override void Action()
    {
        isCool = false;
        cooldownTime = 0.0f;   
    }  

    private void Update()
    {
       
        if (!isCool)
        {
            cooldownTime += Time.deltaTime;
            if(cooldownTime > cooldownTimer)
            {
                isCool = true;
            }
        }
    }
}
