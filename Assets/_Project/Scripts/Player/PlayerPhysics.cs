using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private enum State
    {
        InitialPhysics,
        RecoilPhysicsState,
        NoPhysics,
        CurvePhysicsState


    }

    private State state;

    public bool isWeaponChange = false;

   
    public float speed;

    public AnimationCurve accCurve;

    public float acc;

    public float accSpeed;
    public bool move = false;


    private Rigidbody2D rb2d;
    public CurrentPlayerComponentData playerData;
    public WeaponData currentWeaponData;
    public float waitTime;

    private void Awake()
    {
        SetInitialPysicsState();
    }

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        if (currentWeaponData.WeaponNumber == 3)
        {
            state = State.RecoilPhysicsState;
        }
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

    }
    void CheckWeaponPhysics()
    {
       // Debug.Log("check weapon number");
        if (playerData.weaponNumber == 2)
        {
            rb2d.drag = 10f;
        //    Debug.Log(" weapon number 2");
            state = State.RecoilPhysicsState;
        }
        else {
            rb2d.drag = 0.3f;
            state = State.CurvePhysicsState;
        }
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

        switch (state)
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
        }
    }
    private void RecoilPhysics()
    {
       // Debug.Log("RecoilPhysics");
        rb2d.drag = currentWeaponData.drag;
        rb2d.AddForce(transform.right *currentWeaponData.thrust, ForceMode2D.Impulse);
    }

    private void CurvePhysics()
    {

       
        if (move)
        {
           
            this.acc += 1f / this.accSpeed * Time.fixedDeltaTime;
            this.rb2d.velocity = transform.right * (this.speed * this.accCurve.Evaluate(this.acc));
           
            if (this.acc > 1f)
            {
                this.acc = 1f;
            }
        }
        else if (this.acc > 0f)
        {
            this.acc = this.rb2d.velocity.magnitude / this.speed;
        }




    }


    private void SetInitialPysicsState()
    {
        state = State.InitialPhysics;

        
    }

    
}
