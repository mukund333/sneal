using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;
using SnealUltra.Assets._Project.Scripts.Player;


public class SwitchToggle : MonoBehaviour {
   [SerializeField] RectTransform uiHandleRectTransform ;


   Image backgroundImage, handleImage ;


   Toggle toggle ;

   Vector2 handlePosition ;
   


   void Awake ( ) {
	   

      toggle = GetComponent <Toggle> ( ) ;

      handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;


      toggle.onValueChanged.AddListener (OnSwitch) ;
	  toggle.isOn=true;
	  
      if (toggle.isOn)
         OnSwitch (true) ;
   }

   void OnSwitch (bool on) {
	   	
		if(on==true)
			handleImage.enabled = true;
		else
			handleImage.enabled = false;

		/*
      //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
      uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack) ;

      //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
      backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f) ;

      //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
      handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f) ;
	  */
	  
   }

   void OnDestroy ( ) {
      toggle.onValueChanged.RemoveListener (OnSwitch) ;
   }
}
