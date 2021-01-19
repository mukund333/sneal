using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{

public class Turtle : EnemyManager
{
		private enum State{
			Moving,
			Aiming,
			Charging,
			Attacking,
			Busy,
		}

	//common


	bool isMoving =false;
		[SerializeField]
		private LayerMask layerMask;
		private Rigidbody2D body2d;
		public  GameObject target;
		
		Vector3 targetPosition;
	
		[SerializeField]
		private Transform aimTransform;
		private Transform turtlesprite;
		
		
	//animation 
		private Animator animator;
		private float animSpeed = 1f;
		private string animName = "TurtleTransformAnimation";



	//attack params
	private State state;	
		private Vector3 chargeDir;
		public float chargeSpeed;
		[SerializeField]  private float chargeDelay;

		public float attackRange = 2f;
	

	//movement params
		public  float speed = 2f;  
		private float angle = 90f;
		private float distanceToTarget;
		Vector3 displacementFromTarget;
		Vector3 directionToTarget;
		Vector3 velocity;
		
	
	private void Awake() {
		animator = GetComponentInChildren<Animator> ();
		body2d = GetComponent<Rigidbody2D>();
		SetStateMoving();

		aimTransform = transform.Find("Aim");
		turtlesprite = transform.Find("turtlesprite");

		isMoving = true;
		HideAim();

	}

	private void Update(){
		
		
		switch (state){

			case State.Moving:

				Debug.Log("follow");
				if(isMoving==true)
					TurtleMovement();
				targetPosition = target.transform.position;
				SetAimTarget(targetPosition);
				//ChangeAnimationState(0);
				animator.speed = 1f;

				if(distanceToTarget < attackRange)
				{
					isMoving = false;
					Debug.Log("attack");
					
					
					//state = State.Aiming;



					StartCoroutine(PlayAndWaitForAnim(animator, animName));



				}
				break;

			case State.Aiming:
				
				
				chargeDelay -= Time.deltaTime;
				
				
				targetPosition = target.transform.position;
				SetAimTarget(targetPosition);
				
				animator.speed = 1f;				
				ChangeAnimationState(2);
				

				if (target != null)
				{
					// targetPosition = target.transform.position;

					if (chargeDelay > 0)
					{
						// Too soon to charge, move to it
						//  enemyMain.EnemyPathfindingMovement.MoveToTimer(targetPosition);
						//Debug.Log(enemyMain.EnemyPathfindingMovement);

						Debug.Log("animation");
					//	SetAimTarget(targetPosition);
						ShowAim();
						
					}
					else
					{
						Debug.Log("can charge");
						if (CanChargeToTarget(targetPosition, target))
						{

							chargeDir = (targetPosition - GetPosition()).normalized;
							chargeSpeed = 20f;
							state = State.Charging;

						}
						else
						{
							// Cannot see target, move to it
							//enemyMain.EnemyPathfindingMovement.MoveToTimer(targetPosition);
							TurtleMovement();
							Debug.Log("follow again");
						}
					}


				}

				break;

			case State.Charging:
				HideAim();
				animator.speed = 1f;
				ChangeAnimationState(3);
				float chargeSpeedDropMultiplier = 1f;
				chargeSpeed += chargeSpeed * chargeSpeedDropMultiplier * Time.deltaTime;
				
				//player damage

				/*float hitDistance = 3f;
				RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), chargeDir, hitDistance, layerMask);
				if (raycastHit2D.collider != null) {
					Player player = raycastHit2D.collider.GetComponent<Player>();
				if (player != null) {
                    player.Damage(enemyMain.Enemy, .6f);
                    player.Knockback(chargeDir, 5f);
                    chargeSpeed = 60f;
                    chargeDir *= -1f;
                }
				}*/

			/*	float chargeSpeedMinimum = 10f;
				if (chargeSpeed < chargeSpeedMinimum)
				{
					//state = State.Aiming;
					Debug.Log("disable");
					gameObject.SetActive(false);
					chargeDelay = 1.5f;
				


				}*/

				break;

			case State.Attacking:
				break;
			case State.Busy:
				break;

		} 
	
	
	}

	void FixedUpdate(){
		switch (state){
			case State.Charging:
					//body2d.velocity = chargeDir * chargeSpeed;
					body2d.AddForce(chargeDir * chargeSpeed);
				
				Debug.Log("velocity");
				break;
		}

		//TurtleMovement();
	}

	bool CanChargeToTarget(Vector3 targetPosition, GameObject targetGameObject){
		float targetDistance = Vector3.Distance(GetPosition(), targetPosition);

		float maxChargeDistance = 7f;
		/*if (targetDistance > attackRange)
		{
			return false;

		}*/

		Debug.Log("charge");
		Vector3 dirToTarget = (targetPosition - GetPosition()).normalized;
		RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToTarget, targetDistance, layerMask);
		//Debug.Log(raycastHit2D.collider.gameObject.name);
		return raycastHit2D.collider == null || raycastHit2D.collider.gameObject == targetGameObject;
	}

	private Vector3 GetPosition(){
		return transform.position;
	}

	private void SetStateMoving(){
		state = State.Moving;
	}

	private void TurtleMovement(){
		
	    displacementFromTarget = target.transform.position - transform.position;
	    directionToTarget = displacementFromTarget.normalized;
	    velocity = directionToTarget * speed;
	   
	    distanceToTarget = displacementFromTarget.magnitude;
		
		transform.Translate(velocity * Time.deltaTime);

		

		/*if(distanceToTarget > 0.1f)
		{
			transform.Translate(velocity * Time.deltaTime);
		}*/


		SetAimTarget(targetPosition);

			angle = Mathf.Atan2(displacementFromTarget.y, displacementFromTarget.x) * Mathf.Rad2Deg;
		
			//transform.rotation = new Quaternion(rotx, roty, rotz, rotw);
			//transform.Rotate(0, 0, angle);
	   
	   
   }

	public void SetAimTarget(Vector3 targetPosition){
		Vector3 aimDir = (targetPosition - transform.position).normalized;
		turtlesprite.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(aimDir));
	}

	public static float GetAngleFromVectorFloat(Vector3 dir){
		dir = dir.normalized;
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;

		return n;
	}

	private void ShowAim(){
		aimTransform.gameObject.SetActive(true);
	}

	private void HideAim(){
		aimTransform.gameObject.SetActive(false);
	}
	
	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}

	public IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName){


		//targetAnim.Play(stateName);
		//targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

		animator.speed = 0.5f;
		ChangeAnimationState(1);

		//Wait until we enter the current state
		while (!targetAnim.GetCurrentAnimatorStateInfo(0).IsName(animName))
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
		state = State.Aiming;

	}
	
	private void OnCollisionEnter2D(Collision2D col)
		{
			if (col.collider.CompareTag("Player"))
			{
				col.collider.GetComponent<PlayerStats>().Damage(5);
				//CameraController.instance.initializeCameraShake(3f, 0.05f);
				//ExplosionManager.instance.SpawnDynamicExplosion(col.contacts[0].point, new Vector2(1f, 2f), new Vector2(0.25f, 1.5f), 32, new Vector2(0.02f, 0.1f));


				Kill();

			}
		}

 }
}
