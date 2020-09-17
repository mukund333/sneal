using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class FloatData : MixinBase
{
    [SerializeField]
    float data;
    public CurrentWeaponData weaponDefination;

    public List<MixinBase> updateMixins;

    public override void Awake()
    {
        data = weaponDefination.GetShots();
    }

    public float GetData()
    {
        return data;
    }

    public void SetData(float newData)
    {
        data = newData;
       
        Action();
    }

    public void IncrementData(float num)
    {
        data += num;
        
        Action();
    }

    public override void Action()
    {
		if(updateMixins.Count>0)
		{
			for (int i = 0; i < updateMixins.Count; i++)
			{
				updateMixins[i].Action();
			}
		}
    }
}
