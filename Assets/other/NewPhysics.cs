using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPhysics : MonoBehaviour
{
	public enum State{
			NoPhysics,
			IntialPhysics,
			SecondPhysics,
			BulletDelay
		}
	public State state;
	public float drag;
	public float thrustForce;
	public float accelaration;
	public Rigidbody2D rb2d;
	public float speed;
	public bool onetime = false;
	//public float maxSpeed;
	public float waitTime;
	
    // Start is called before the first frame update
    void Start()
    {
		accelaration=0;
        rb2d= GetComponent<Rigidbody2D>();
		state = State.NoPhysics;
		
		
    }

	void Update()
    {
			if(Input.GetKeyDown(KeyCode.Space))
				{
					state = State.IntialPhysics;
				}
				
				speed = rb2d.velocity.magnitude;
		        
		
		
		if(rb2d.velocity.magnitude > thrustForce)
		{
			Debug.Log("Speed :"+speed); 
		}
		
		Debug.Log("Time :"+waitTime); 
		 
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		
		switch (state){

			case State.NoPhysics:
				Debug.Log("NoPhysics");  
				
				//Debug.Log("accelaration : "+accelaration); 
				
			break;
			
			case State.IntialPhysics:
				Debug.Log("IntialPhysics");  
				onetime = false;
				if (!onetime)
				{
					
					accelaration = thrustForce-rb2d.velocity.magnitude;
					RecoilPhysics(accelaration);
					//StartCoroutine(TimerCoroutine());
					state = State.SecondPhysics;
					onetime = true;
				}
				Debug.Log("accelaration : "+accelaration); 
				
				
			break;
			
			case State.SecondPhysics:
					onetime = false;
					if (!onetime)
					{
				
					StartCoroutine(TimerCoroutine());
					state = State.BulletDelay;
					onetime = true;
					}
				
				
				
			break;
			
			case State.BulletDelay:
				accelaration=0;
			break;
		
		
		
		/*switch (state){

			case State.NoPhysics:
				Debug.Log("NoPhysics");  
				
				//Debug.Log("accelaration : "+accelaration); 
				
			break;
			
			case State.IntialPhysics:
				Debug.Log("IntialPhysics");  
				//onetime = false;
				if (!onetime)
				{
					RecoilPhysics(thrustForce);
					StartCoroutine(TimerCoroutine());
					onetime = true;
				}
				Debug.Log("accelaration : "+accelaration); 
				
				
			break;
			
			case State.SecondPhysics:
				Debug.Log("SecondPhysics");  
				onetime = false;
				if (!onetime)
				{	
					accelaration =0;
					
						accelaration = thrustForce-rb2d.velocity.magnitude;
					
					
					Debug.Log("magnitude :"+rb2d.velocity.magnitude);
					Debug.Log("accelaration : "+accelaration); 
					RecoilPhysics(accelaration);
					
					onetime = true;
				}
				Debug.Log("accelaration : "+accelaration); 
				state = State.BulletDelay;
			
			break;
			
			case State.BulletDelay:
				accelaration =0;
				Debug.Log("BulletDelay"); 
				onetime = false;
				if (!onetime)
				{
					
					StartCoroutine(TimerCoroutine());
					onetime = true;
				}
				
			break;
			
			
			
		}*/
		
		}
		
		
		 
    }
	
	IEnumerator TimerCoroutine()
	{
		/*float elapsedTime = 0;

		while (elapsedTime <= waitTime)
		{
			elapsedTime += Time.deltaTime;
			Debug.Log("elapsedTime :"+elapsedTime); 
			yield return null;
		}*/
		yield return new WaitForSeconds(waitTime);
		state = State.IntialPhysics;  
		
		//StopCoroutine(TimerCoroutine());
		
		
	}
	
	private void RecoilPhysics(float thrust)
	{
		
       // Debug.Log("RecoilPhysics");
        rb2d.drag = drag;
        rb2d.AddForce(transform.right *thrust, ForceMode2D.Impulse);
		Debug.Log("RecoilPhysics called"); 
		
    }
}
