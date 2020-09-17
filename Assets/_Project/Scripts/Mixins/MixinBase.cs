using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Core;
using System;

namespace SnealUltra.Assets._Project.Scripts.Mixins
{
    public class MixinBase : Behave
    {

        public virtual void Awake()
        {
            
        }

        public virtual bool Check()
        {
            return true;
        }

        public virtual void Action()
        {

        }

       

        public void CheckAndAction()
        {
            if(Check())
            {
                Action();
            }
        }

    }
}