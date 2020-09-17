using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDataMixins : MixinBase
{
    public List<MixinBase> listIntializeDataMixins;

    public override void Awake()
    {
        for (int i = 0; i < listIntializeDataMixins.Count; i++)
        {
            listIntializeDataMixins[i].Awake();
        }
    }
}
