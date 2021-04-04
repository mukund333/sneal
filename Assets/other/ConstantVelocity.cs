using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
	
	public float speed;
	public Rigidbody2D rb2d;
	
	[SerializeField] private VirtualJoystick joystick;
	[SerializeField] private Vector2 direction;
	[SerializeField] private float Magnitude;
	[SerializeField] private float turnRate = 8f;
	public float accSpeed;
	public float accTime;
	 
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
		joystick = FindObjectOfType<VirtualJoystick>();
		
    }

	void Update()
    {
		direction = PlayerInput().normalized;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
         
		 Vector3 velocity = direction * speed;
		 Vector3 moveAmount = velocity * Time.deltaTime;
		// transform.Translate(moveAmount);
		 rb2d.velocity = moveAmount;
		 Magnitude = rb2d.velocity.magnitude;
		 Rotate();
    }
	
	 private Vector2 PlayerInput()
        {
            return new Vector2(joystick.Horizontal(), joystick.Vertical());
        }
	
	private void Rotate()
        {
            if (Mathf.Abs(direction.x) > 0.05f || Mathf.Abs(direction.y) > 0.05f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
                Quaternion b = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
                transform.rotation = Quaternion.Slerp(transform.rotation, b, Time.fixedDeltaTime * turnRate);
            }
        }
}
