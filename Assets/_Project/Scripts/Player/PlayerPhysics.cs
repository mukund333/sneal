using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;

public class PlayerPhysics : MonoBehaviour
{
   [SerializeField] PlayerDragCheck dragCheck;
    private enum State
    {
        InitialPhysics,
        RecoilPhysicsState,
        NoPhysics,
        CurvePhysicsState


    }
	
	public Vector3 v;

    private State state;

    public bool isWeaponChange = false;

   
    public float speed;

    public AnimationCurve accCurve;

    public float acc;

    public float accSpeed;
    public bool move = false;
	public bool isApplyingDrag=false;
	
    private Rigidbody2D rb2d;
    public CurrentPlayerComponentData playerData;
    public WeaponData currentWeaponData;
    public float waitTime;
	public Transform sprite;
	public EquipPlayerWeapon equipPlayerWeapon;


    private void Awake()
    {
        SetInitialPysicsState();
    }

    void Start()
    {
		sprite = base.transform.GetChild(2);
        
        rb2d = GetComponent<Rigidbody2D>();
		equipPlayerWeapon = GetComponent<EquipPlayerWeapon>();
      /*  if (currentWeaponData.WeaponNumber == 3)
        {
            state = State.RecoilPhysicsState;
        }*/
    }
    private void Update()
    {
        currentWeaponData = playerData.GetWeaponDataByName();

        //inversion
        if (!isWeaponChange)
        {
            CheckWeaponPhysics();
        }
        isWeaponChange = true;

        CheckWeponChange();
		
		
		/*switch (state)
        {

            case State.InitialPhysics:
                rb2d.velocity = Vector2.zero;
                //Debug.Log("InitialPhysics");

                break;

            case State.CurvePhysicsState:
               
                CurvePhysics();
                //Debug.Log("CurvePhysics");
                break;

            case State.RecoilPhysicsState:

                if (playerData.GetIsRecoilingComplete() == true)
                {
                    RecoilPhysics();
                }

                if (playerData.GetIsRecoilingComplete() == false)
                {
                    // RecoilPhysics();
                    state = State.NoPhysics;
                }

                break;

            case State.NoPhysics:

                if (playerData.GetIsRecoilingComplete() == true)
                {
                    state = State.RecoilPhysicsState;
                }
                else {
                   // Debug.Log("NoPhysics");
                }

                break;
        }*/

    }
    void CheckWeaponPhysics()
    {
		state = State.CurvePhysicsState;
       // Debug.Log("check weapon number");
      /*  if (playerData.weaponNumber == 2)
        {
            rb2d.drag = 10f;
        //    Debug.Log(" weapon number 2");
            state = State.RecoilPhysicsState;
        }
        else {
            rb2d.drag = 0.3f;
            state = State.CurvePhysicsState;
        }*/
    }

    void CheckWeponChange()
    {
        if (playerData.isEquipDirect == true)
        {
           // rb2d.drag = 10f;
           
            isWeaponChange = false;
        }
		
           
    }

   

    //public void SetData(WeaponData weaponData)
    // {
    //     currentWeaponData = weaponData;
    //     Debug.Log(""+currentWeaponData.name);
    // }
    private void FixedUpdate()
    {
		CurvePhysics();
         
    }
    private void RecoilPhysics()
    {
       // Debug.Log("RecoilPhysics");
        rb2d.drag = currentWeaponData.drag;
        rb2d.AddForce(transform.right *currentWeaponData.thrust, ForceMode2D.Impulse);
    }

    private void CurvePhysics(){    
        if (equipPlayerWeapon.IsShooting())
        {
           
            this.acc =acc + 1f / this.accSpeed * Time.fixedDeltaTime;
            
			
			 
			this.rb2d.velocity = transform.right * (this.speed * this.accCurve.Evaluate(this.acc));
			v = this.rb2d.velocity;
			acc = Mathf.Clamp(acc, 0f, 1f);
				
				/*if(dragCheck.playrDrag==true)
				{
					rb2d.drag = 400f;
				}
				if(dragCheck.playrDrag == false)
				{
					rb2d.drag = 0.3f;
				}*/
				
           /* if (this.acc > 1f)
            {
                this.acc = 1f;
            }*/
			
			
        }
       else if (this.acc > 0f)
        {
            this.acc =(float)System.Math.Round( (this.rb2d.velocity.magnitude / this.speed),2 );
        }




    }
	
	private static Vector3 RoundVector3( Vector3 v ) {
        return new Vector3((float)System.Math.Round(v.x,2), (float)System.Math.Round(v.y,2), (float)System.Math.Round(v.z,2) );
    }


    private void SetInitialPysicsState(){
        state = State.InitialPhysics;

        
    }

    
}
