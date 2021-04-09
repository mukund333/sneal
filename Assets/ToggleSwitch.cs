using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using SnealUltra.Assets._Project.Scripts.Player;



public class ToggleSwitch : MonoBehaviour,IPointerDownHandler
{
	[SerializeField] private bool _isOn = true;
	
	[SerializeField] private EquipPlayerWeapon equipPlayerWeapon;
	
	public bool isOn
	{
		get 
		{
			return _isOn;
		}
	}
	[SerializeField] private RectTransform toggleIndicator;
	[SerializeField] Image backgroundImage;
	[SerializeField] Color onColor;
	[SerializeField] Color offColor;
	
	private float offx;
	private float onx;

	[SerializeField] private float tweenTime = 0.25f;
	
	public delegate void ValueChanged(bool value);
	public event ValueChanged valueChanged;
	
	
	private void OnEnable()
	{
		equipPlayerWeapon = FindObjectOfType<EquipPlayerWeapon>();
		Toggle(isOn);
		
	}
	
    // Start is called before the first frame update
    void Start()
    {		
			offx = toggleIndicator.anchoredPosition.x;
			onx = backgroundImage.rectTransform.rect.width - toggleIndicator.rect.width;
			
			
    }

	private void Toggle(bool value)
	{
		if(value != isOn)
		{
			_isOn = value;
			ToggleColor(isOn);
			MoveIndicator(isOn);
			if(valueChanged != null)
			{
				valueChanged(isOn);
			}
		}
		
		equipPlayerWeapon.isToggling = true;
	}
	
	private void ToggleColor(bool value)
	{
		if(value)
		{
			backgroundImage.DOColor(onColor,tweenTime);
		}else{
			backgroundImage.DOColor(offColor,tweenTime);
		}
	}
	
	private void MoveIndicator(bool value)
	{
		if(value)
			toggleIndicator.DOAnchorPosX(onx,tweenTime);
		else
			toggleIndicator.DOAnchorPosX(offx,tweenTime);
	}

    
    void Update()
    {
        
    }
	
	public  void OnPointerDown(PointerEventData eventData)
	{
		Toggle(!isOn);
	}
}
