using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;


public class CheckClip : MixinActionable
{
    public FloatData clip;
    public float ammoPerShot;

    public override bool Check()
    {
        if(clip.GetData() - ammoPerShot < 0)
        {
            actionMixin.CheckAndAction();

            return false;
        }

        return true;
    }
    public override void Action()
    {
        clip.IncrementData(-ammoPerShot);
    }
}
