using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleAI : MonoBehaviour
{
   
   
  
  public  GameObject player;
  // SpriteRotation spriteRotation;
  
   public float speed = 2f;  
   public float blastRange = 4f;
   private float angle = 90f;
   
   Vector3 currentPlayerPosition;
   
   Vector3 displacementFromTarget;
   Vector3 directionToTarget;
   Vector3 velocity;
   float distanceToTarget;
   
  
   
   
   public bool isMoving = true;
   bool isAttaking = false;
   
    void Awake()
    {
       
        player = GameObject.Find("player");
       // spriteRotation = GetComponent<SpriteRotation>();
    }
   
   
   void Update()
   {
	  
		if(isMoving==true)
			EnemyMovement();
		
		if(distanceToTarget < blastRange)
		{
		   isMoving=false;
	    }

	
   }
   
   void FixedUpdate()
   {
	   if(isMoving ==false)
	   {
			if(!isAttaking)
			{
				 currentPlayerPosition = player.transform.position;
				Attack();
				isAttaking = true;
				
			}
	   }
   }
   
   void EnemyMovement()
   {
	    displacementFromTarget = player.transform.position - transform.position;
	    directionToTarget = displacementFromTarget.normalized;
	    velocity = directionToTarget * speed;
	   
	    distanceToTarget = displacementFromTarget.magnitude;
		
		transform.Translate(velocity * Time.deltaTime);
	   
	   /*if(distanceToTarget > 0.1f)
	   {
		   transform.Translate(velocity * Time.deltaTime);
	   }*/
	   
	    
       // if (player != null) {
          
            angle = Mathf.Atan2(displacementFromTarget.y, displacementFromTarget.x) * Mathf.Rad2Deg;
       // }

       /* if (spriteRotation != null) {
            spriteRotation.rotation = angle;
        }*/
	   
	   
   }
   
   
   void Attack()
   {
	    Debug.Log(currentPlayerPosition);
		
		
		Vector3 direction = currentPlayerPosition - transform.position;
		direction = direction + new Vector3(100,100,0);
	    directionToTarget = direction.normalized;
		velocity = directionToTarget * speed;
			transform.Translate(velocity * Time.deltaTime);
		
		
		
		Debug.DrawRay(transform.position,direction,Color.green);
		//transform.Translate(direction*Time.deltaTime*100);
		
	

		
		//gameObject.SetActive(false);
	   
   }
   
}
