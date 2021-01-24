using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Che : MonoBehaviour
{
	public  GameObject target;
	public float turnRate;
	public float Speed;
	private Rigidbody2D rb2d;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
    {
        moveBird();
    }
	
	private void moveBird()
	{
		Vector2 dir = target.transform.position - transform.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
				Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
				transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * turnRate);
				rb2d.velocity = transform.right * Speed;
	}
}
