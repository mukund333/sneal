using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTouch : MonoBehaviour
{

    public bool isDown;

	public int screenWidth;
	
	private void Awake()
	{
		this.screenWidth = Screen.width;
	}

	private void Update()
	{
		this.isDown = false;
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				if (Input.GetTouch(i).position.x > (float)(this.screenWidth / 2))
				{
					this.isDown = true;
					break;
				}
				this.isDown = false;
			}
		}
	}

	public bool IsDown()
	{
		return this.isDown && this.isDown;
	}

}
