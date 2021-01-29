using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{
public class Drone : EnemyManager
{
	private enum State{
			Moving,
			Detection,
			Blast,
			Attacking,
			Busy,
		}
	
	private State state;
	
	//movement params
	public  float speed = 2f;  
	private float distanceToTarget;
	Vector3 displacementFromTarget;
	Vector3 directionToTarget;
	Vector3 velocity;
	
	
	private Rigidbody2D body2d;
	[SerializeField] private GameObject target;
	[SerializeField] private LayerMask layerMask;
	
	
	
	
	[SerializeField] private float blastRange = 1f;
	[SerializeField] private float chargeDelay;
	
	
	//animation 
	//private Animator animator;
	//private string animName = "";
		
	private void Awake() {
		//animator = GetComponentInChildren<Animator> ();
		body2d = GetComponent<Rigidbody2D>();
		
		SetStateMoving();
		

	}
	
	
	private void Update(){
		switch (state){

			case State.Moving:
		
				DroneMovement();
				Debug.Log("follow");
				
				if(distanceToTarget < blastRange)
				{
					
					state = State.Detection;
				}
				break;
				
			case State.Detection:
				
				chargeDelay -= Time.deltaTime;
				
				if (target != null)
				{
					
					if (chargeDelay > 0)
					{						
						Debug.Log("beep beep beep animation");
						state = State.Blast;
						//StartCoroutine(PlayAndWaitForAnim(animator, animName));	
					}
					else
					{
							SetStateMoving();
							Debug.Log("follow again");
						
					}


				}
				
				
				
				break;
			
			case State.Blast:
				Debug.Log("Blast");
				Detonate();
				
				
				
				break;
				
			
		}
	}
	
	private void SetStateMoving(){
		state = State.Moving;
	}
	
	private void DroneMovement(){
		
	    displacementFromTarget = target.transform.position - transform.position;
	    directionToTarget = displacementFromTarget.normalized;
	    velocity = directionToTarget * speed;
	   
	    distanceToTarget = displacementFromTarget.magnitude;
		
		transform.Translate(velocity * Time.deltaTime);

		

		/*if(distanceToTarget > 0.1f)
		{
			transform.Translate(velocity * Time.deltaTime);
		}*/


		

			
	}  
	
	/*private void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}*/
	
	public IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName){


		//targetAnim.Play(stateName);
		//targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

		//animator.speed = 0.5f;
		//ChangeAnimationState(1);

		//Wait until we enter the current state
		while (!targetAnim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
		{
			yield return null;
		}

		float counter = 0;
		float waitTime = targetAnim.GetCurrentAnimatorStateInfo(0).length;

		//Now, Wait until the current state is done playing
		while (counter < (waitTime))
		{
			counter += Time.deltaTime;
			yield return null;
		}

		//Done playing. Do something below!
		Debug.Log("Done Playing");
		state = State.Blast;

	}

	private void Detonate(){
		//ChangeAnimationState(0);
		
		Collider2D collider2D = Physics2D.OverlapCircle(transform.position, 32f, layerMask);
			if (collider2D != null && collider2D.CompareTag("Player"))
			{
				//collider2D.GetComponent<SubmarineStats>().Damage(this.damage);
				Debug.Log("damage to player");
			}
			
			Debug.Log("drone die");
			Kill();
			
	}
}
}
