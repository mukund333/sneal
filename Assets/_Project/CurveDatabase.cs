using System;
using UnityEngine;


public class CurveDatabase : MonoBehaviour
{
	public Curve[] curves;

	
	private static CurveDatabase _instance;
	
	public static CurveDatabase instance
	{
		get
		{
			if (CurveDatabase._instance == null)
			{
				CurveDatabase._instance = UnityEngine.Object.FindObjectOfType<CurveDatabase>();
			}
			return CurveDatabase._instance;
		}
	}

	
	public AnimationCurve GetCurve(int index)
	{
		for (int i = 0; i < this.curves.Length; i++)
		{
			if (i == index)
			{
				return this.curves[i].curve;
			}
		}
		return null;
	}

	

}
