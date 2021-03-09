using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveTest : MonoBehaviour
{
	public float speed;

	public AnimationCurve accCurve;

	public float acc;

	public float accSpeed;

	private Rigidbody2D rb2d;

	public bool move = false;

	private Vector2 dir;

	[SerializeField] private VirtualJoystick joystick;

	[SerializeField]private Transform sprite;
	void Start()
	{
		this.sprite = base.transform.Find("sprite");
		this.rb2d = base.GetComponent<Rigidbody2D>();
		
	}

    private void FixedUpdate()
    {
		this.joystick = UnityEngine.Object.FindObjectOfType<VirtualJoystick>();
		this.dir = new Vector2(this.joystick.Horizontal(), this.joystick.Vertical());
		this.Rotate();
		this.Shoot();

	}

    private void Shoot()
    {
		//if(Input.GetKey(KeyCode.Space))
		if(move==true)
        {
			acc += 1f/ accSpeed * Time.fixedDeltaTime;

			rb2d.velocity = transform.right * (speed * accCurve.Evaluate(this.acc));

			if (acc > 1f)
			{
				acc = 1f;
			}
		}
		else if (acc > 0f)
		{
			acc = rb2d.velocity.magnitude / speed;
		}

	}

	private void Rotate()
	{
		if (Mathf.Abs(this.dir.x) > 0.05f || Mathf.Abs(this.dir.y) > 0.05f)
		{
			float angle = Mathf.Atan2(this.dir.y, this.dir.x) * 57.29578f;
			Quaternion b = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
			this.sprite.transform.rotation = Quaternion.Slerp(this.sprite.rotation, b, Time.fixedDeltaTime * 6f);
			if (this.sprite.rotation.eulerAngles.z < 270f && this.sprite.rotation.eulerAngles.z > 90f)
			{
				this.sprite.localScale = new Vector3(1f, -1f, 1f);
			}
			else
			{
				this.sprite.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}
}
