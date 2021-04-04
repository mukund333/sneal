using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public static CameraController instance;

	public bool follow;

	public float dampTime;

	private Vector3 truePos = new Vector3(0f, 0f, -10f);

	private Vector3 preShakePos;

	public GameObject target;

	public Camera cam;

	private float shake;

	private float shakeAmount;

	private float decreaseFactor;

	public int xOffset;

	public int yOffset;

	public int safeZoneX;

	public int safeZoneY;

	private Vector3 velocity = Vector3.zero;

	private Transform myTransform;

	public bool bounds;

	public Vector2 minBounds;

	public Vector2 maxBounds;

	private int antiAliasing;
	
	private void Start()
	{
		CameraController.instance = this;
		this.myTransform = base.transform;
	}

	private void OnGUI()
	{
	}

	private void LateUpdate()
	{
		if (this.target == null)
		{
			this.target = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		if (this.shake > 0f)
		{
			this.myTransform.position = new Vector3(Mathf.Round(this.myTransform.position.x + UnityEngine.Random.insideUnitCircle.x * this.shakeAmount), Mathf.Round(this.myTransform.position.y + UnityEngine.Random.insideUnitCircle.y * this.shakeAmount), -10f);
			this.shake -= Time.fixedDeltaTime;
		}
		if (this.follow && this.target && Time.timeScale > 0f)
		{
			Vector2 vector = new Vector2(VirtualJoystick.instance.Horizontal(), VirtualJoystick.instance.Vertical());
			Vector3 vector2 = Vector3.SmoothDamp(this.myTransform.position, new Vector3(this.target.transform.position.x + (float)this.xOffset, this.target.transform.position.y + (float)this.yOffset, -10f), ref this.velocity, this.dampTime);
			this.myTransform.position = new Vector3(vector2.x + -vector.x, vector2.y + -vector.y, -10f);
			if (this.bounds)
			{
				base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x, this.minBounds.x, this.maxBounds.x), Mathf.Clamp(base.transform.position.y, this.minBounds.y, this.maxBounds.y), -10f);
			}
		}
	}

	public void initializeCameraShake(float shakePwr, float shakeDur)
	{
		this.preShakePos = base.transform.position;
		this.shake = shakeDur;
		this.shakeAmount = shakePwr;
	}

	public Vector3 RoundPosition(Vector3 transToRound)
	{
		Vector3 result = new Vector3((float)Mathf.RoundToInt(transToRound.x), (float)Mathf.RoundToInt(transToRound.y), (float)Mathf.RoundToInt(transToRound.z));
		return result;
	}

	public void SetMinBounds()
	{
		this.minBounds = base.transform.position;
	}

	public void SetMaxBounds()
	{
		this.maxBounds = base.transform.position;
	}

	
}
