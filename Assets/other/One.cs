using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
    bool onetime = false;
	
	void Update()
	{
		if (!onetime)
		{
			Activate();
			onetime = true;
		
			Debug.Log(onetime);
		}
  
		
  
	}
	
	void Activate()
	{
		//Debug.Log("boom");
	}
}
