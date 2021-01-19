using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScreenPositions : MonoBehaviour
{

    public Vector3 vpoints = new Vector3(0,0,0);
    public GameObject s;
    public bool fl=true;

    public float timer = 10f;

    public GameObject missile;
    public bool isfiremissile = false;

    bool stopTimer = false;
    

    // Start is called before the first frame update
    void Start()
    {
        vpoints = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 10));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = vpoints;

        if (fl == true) 
        FollowerPoint();

        if (stopTimer == false)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
       

        if (timer < 0)
        {
            stopTimer = true;
            fl = false;
           

        }

        if(isfiremissile==true)
        {
            isfiremissile = false;
            timer = 100;
            FireMissile();
           

        }
           

        
    }

    private void FireMissile()
    {
        Instantiate(missile,transform.position,transform.rotation);
    }

    public void FollowerPoint()
    {
        vpoints.y = s.transform.position.y;
    }
}
