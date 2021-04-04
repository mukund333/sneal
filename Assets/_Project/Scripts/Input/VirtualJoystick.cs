using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200000E RID: 14
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	
	// Token: 0x0400003F RID: 63
	private Image bgImg;

	// Token: 0x04000040 RID: 64
	private Image joystickImg;

	// Token: 0x04000041 RID: 65
	public Vector2 inputVector;

	// Token: 0x04000042 RID: 66
	private static VirtualJoystick _instance;
	
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000032 RID: 50 RVA: 0x0000338D File Offset: 0x0000158D
	public static VirtualJoystick instance
	{
		get
		{
			if (VirtualJoystick._instance == null)
			{
				VirtualJoystick._instance = UnityEngine.Object.FindObjectOfType<VirtualJoystick>();
			}
			return VirtualJoystick._instance;
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x000033AE File Offset: 0x000015AE
	private void Start()
	{
		this.bgImg = base.GetComponent<Image>();
		this.joystickImg = base.transform.GetChild(0).GetComponent<Image>();
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000033D4 File Offset: 0x000015D4
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 vector;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.bgImg.rectTransform, ped.position, ped.pressEventCamera, out vector))
		{
			vector.x /= this.bgImg.rectTransform.sizeDelta.x;
			vector.y /= this.bgImg.rectTransform.sizeDelta.y;
			this.inputVector = new Vector2(vector.x * 2f + 1f, vector.y * 2f - 1f);
			this.inputVector = ((this.inputVector.magnitude <= 1f) ? this.inputVector : this.inputVector.normalized);
			this.joystickImg.rectTransform.anchoredPosition = new Vector3(this.inputVector.x * (this.bgImg.rectTransform.sizeDelta.x / 3f), this.inputVector.y * (this.bgImg.rectTransform.sizeDelta.y / 3f));
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00003523 File Offset: 0x00001723
	public virtual void OnPointerDown(PointerEventData ped)
	{
		this.OnDrag(ped);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000352C File Offset: 0x0000172C
	public virtual void OnPointerUp(PointerEventData ped)
	{
		this.inputVector = Vector3.zero;
		this.joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003558 File Offset: 0x00001758
	public float Horizontal()
	{
		if (this.inputVector.x != 0f)
		{
			return this.inputVector.x;
		}
		return Input.GetAxis("Horizontal");
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003585 File Offset: 0x00001785
	public float Vertical()
	{
		if (this.inputVector.y != 0f)
		{
			return this.inputVector.y;
		}
		return Input.GetAxis("Vertical");
	}

	
}
