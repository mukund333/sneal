using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childCamera : MonoBehaviour
{
	public static childCamera instance;
	 public GameObject player;
	 public Vector3 targetPosition;
	
	 public float smoothTime = 0.3F;
     public Vector3 velocity = Vector3.zero;
	 
	 public float shake;

	public float shakeAmount;
    // Start is called before the first frame update
    void Start()
    {
		childCamera.instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
			
          transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
		  
		  
		
		//
		 
		if (this.shake > 0f)
		{
			transform.position = new Vector3(Mathf.Round(transform.position.x + UnityEngine.Random.insideUnitCircle.x * this.shakeAmount), Mathf.Round(transform.position.y + UnityEngine.Random.insideUnitCircle.y * this.shakeAmount), -10f);
			this.shake -= Time.fixedDeltaTime;
		}


    }
	
	public void initializeCameraShake(float shakePwr, float shakeDur)
	{
		
		this.shake = shakeDur;
		this.shakeAmount = shakePwr;
	}

	private static Vector3 RoundVector3( Vector3 v ) {
        return new Vector3((float)System.Math.Round(v.x,2), (float)System.Math.Round(v.y,2), (float)System.Math.Round(v.z,2) );
    }
}
