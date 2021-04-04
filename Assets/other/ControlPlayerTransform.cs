using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = RoundVector3(this.transform.position);
		
    }
	
	private static Vector3 RoundVector3( Vector3 v ) {
        return new Vector3((float)System.Math.Round(v.x,2), (float)System.Math.Round(v.y,2), (float)System.Math.Round(v.z,2) );
    }
}
