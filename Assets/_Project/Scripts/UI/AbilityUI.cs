using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilityUI : MonoBehaviour
{
	public Text timeText;
    public Color PowerGunColor = Color.red;
    public Color ShieldColor = Color.green;
    public Color DefaultColor = Color.white;
    
    public Image image;

    public void ChangeTimeText(float tm)
    {
        timeText.text = tm.ToString("f0");
    }
    public void ChangeAbilityColorUI(Color color)
    {
        image.color = color;
    }

    
}
