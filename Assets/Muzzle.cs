using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
	public Animator animator;
	
	public bool IsMuzzle;
    // Start is called before the first frame update
    void Start()
    {	IsMuzzle =false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      playAnimation();
		
    }
	
	void playAnimation()
	{
		 if(IsMuzzle == true)
		 {
		   ChangeAnimationState(1);
		   
		   
	  	}else{
		   ChangeAnimationState(0);
	   }
	}
	
	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
	
}
