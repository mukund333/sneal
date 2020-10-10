using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public float Speed =1;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
		transform.Translate(movement * Speed * Time.deltaTime);
    }
}
