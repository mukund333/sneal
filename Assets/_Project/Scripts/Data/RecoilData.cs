using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RecoilData", menuName = "RecoilData")]
public class RecoilData : ScriptableObject
{
    public bool isRecoilingComplete;
    public float rigidbodyData = 0;
	
	public void SetRecoil(bool isRecoil)
	{
		isRecoilingComplete = isRecoil;
	}
	
}
