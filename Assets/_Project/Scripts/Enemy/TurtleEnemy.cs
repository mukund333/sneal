using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SnealUltra.Assets._Project.Scripts.Player;
namespace SnealUltra.Assets._Project.Scripts.Enemy
{

[RequireComponent(typeof(Rigidbody2D))]
public class TurtleEnemy : EnemyManager
{
	public bool debug;


	private enum State{
		Moving,
		Aiming,
		Charging,
		Attacking,
		Busy,
	}
	

	#region common params	
		[Header("Common Settings")]
		[SerializeField] private Rigidbody2D body2d;
		[SerializeField] private Transform target;
		[SerializeField] private Transform turtlesprite;
		[SerializeField] private PlayerShield playerShield;
		[SerializeField] private LayerMask layerMask;
		[SerializeField] private float distance;
		
	 	private State state;
		
		
	#endregion

	#region movement params
		[Header("Movement Settings")]
		[SerializeField]
		private float speed;
		private float angle = 90f;
		private float distanceToTarget;
		Vector3 displacementFromTarget;
		Vector3 directionToTarget;
		Vector3 velocity;
    #endregion
	
	#region animation params
		private Animator animator;
		private float animSpeed;
		private string animName;
	#endregion
	
	#region aim params
		[Header("Aim Settings")]
		[SerializeField]private Vector3 targetPosition;
		[SerializeField]private float chargeDelay;

	#endregion
	
	#region attack params
		[Header("Attack Settings")]
		[SerializeField] private float attackRange;	
		[SerializeField] private Vector3 chargeDir;
		[SerializeField] private float chargeSpeed;
	#endregion

	private void Awake(){
		playerShield = FindObjectOfType<PlayerShield>();
		body2d = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		
	}

	private void OnEnable(){
		
		Configure();
		SetStateMoving();
		
	}

	private void Start(){
		try
		{
			target = FindObjectOfType<PlayerMovement>().transform;
		}
		catch (Exception ex)
		{
			Log(""+ex);
		}
	}

	private void Update(){
		
		DistanceCal();
		SelfDestruction();

	
			
		switch (state)
		{

			case State.Moving:
					IsImmortal = false;
					TurtleMovement();
					SetAimTarget(target.transform.position);
					
					if(distance <= attackRange)
					{
						//first finish animation trasition movement animation to aim animation
						//state = State.Aiming;
						StartCoroutine(PlayAndWaitForAnim(animator, animName));
					}
				
				break;

			case State.Aiming:
					IsImmortal = true;
					Log("Aiming");
					
					chargeDelay -= Time.deltaTime;
					
					targetPosition = target.transform.position;
					SetAimTarget(targetPosition);
					
					Log(""+CanChargeToTarget(targetPosition, target.gameObject));	
					
					animator.speed = 1f;				
				    ChangeAnimationState(2);
					
					if (chargeDelay > 0)
					{
						Log("charge Delay");
					}else{
						Log("can charge ?");
						if (CanChargeToTarget(targetPosition, target.gameObject))
						{

							chargeDir = (targetPosition - transform.position).normalized;
							chargeSpeed = 20f;
							state = State.Charging;

						}else{
							Log("LayerMask is not player");
						}
					}
					
				break;

			case State.Charging:
					animator.speed = 1f;
					ChangeAnimationState(3);
					IsImmortal = true;
					//float chargeSpeedDropMultiplier = 1f;
					float chargeSpeedUpMultiplier = 1f;
					chargeSpeed += chargeSpeed * chargeSpeedUpMultiplier * Time.deltaTime;
					
				break;

			case State.Attacking:
				break;

			case State.Busy:
				break;
		}
	  
	}

	private void FixedUpdate(){
		switch (state){
			case State.Charging:
					
					body2d.AddForce(chargeDir * chargeSpeed);
					
				break;
		}
	}

	private void DistanceCal(){
		if (target != null)
		{
			distance = Vector3.Distance(target.position, transform.position);
		}

		if (target == null)
		{
			LogWarning("target is null");
		}
	}

	private void TurtleMovement(){
		//defult animation

		displacementFromTarget = target.transform.position - transform.position;
		directionToTarget = displacementFromTarget.normalized;
		velocity = directionToTarget * speed;

		distanceToTarget = displacementFromTarget.magnitude;

		transform.Translate(velocity * Time.deltaTime);

		Log("turtle moving");
		
	}

	private void SetStateMoving(){
		state = State.Moving;
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

	bool CanChargeToTarget(Vector3 targetPosition, GameObject targetGameObject){
		float targetDistance = Vector3.Distance(transform.position, targetPosition);

		//float maxChargeDistance = 7f;
		/*if (targetDistance > attackRange)
		{
			return false;

		}*/

		
		Vector3 dirToTarget = (targetPosition - transform.position).normalized;
		RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, dirToTarget, targetDistance, layerMask);
			Log(raycastHit2D.collider.gameObject.name);
		return raycastHit2D.collider == null || raycastHit2D.collider.gameObject == targetGameObject;
	}
	
	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
	
	public IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName){
		speed=0;
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
		Log("Done Playing");
		state = State.Aiming;

	}
	
	private void OnCollisionEnter2D(Collision2D col){
			if (col.collider.CompareTag("Player"))
			{
				if (playerShield.IsShieldOn)
				{
					col.collider.GetComponent<PlayerShield>().DamageToShield(5);
				}
				else
				{
					col.collider.GetComponent<PlayerStats>().Damage(5);
				}
				//CameraController.instance.initializeCameraShake(3f, 0.05f);
				//ExplosionManager.instance.SpawnDynamicExplosion(col.contacts[0].point, new Vector2(1f, 2f), new Vector2(0.25f, 1.5f), 32, new Vector2(0.02f, 0.1f));


				Kill();

			}
		}
	
	private void SelfDestruction(){
		if(distance>150)
			Kill();
	}
	
    #region Logs

	private void Log(string _msg){
			if (!debug) return;
			Debug.Log("[TurtleEnemy] :"+_msg);
		}

	private void LogWarning(string _msg){
			if (!debug) return;
			Debug.LogWarning("[TurtleEnemy] :" +_msg);
		}

    #endregion

	private void Configure(){
		IsImmortal = false;
		animName = "TurtleTransformAnimation";
		animSpeed = 1f;
		turtlesprite = this.gameObject.transform.GetChild(0);
		targetPosition = Vector3.zero;
		chargeDelay = 1;
		chargeDir = Vector3.zero;
		chargeSpeed = 20f;
		speed = 10f;
		
		try
		{
			target = FindObjectOfType<PlayerMovement>().transform;
		}
		catch (Exception ex)
		{
			Log(""+ex);
		}
	}

	private void Dispose(){
			IsImmortal = false;
			target = null;
		turtlesprite = null;
		targetPosition = Vector3.zero;
		chargeDelay = 0;
		chargeDir = Vector3.zero;
		chargeSpeed =0;
		distance = 0;
		
		
		
		
	}

	void OnDisable(){
		Dispose();
	}
}

}


