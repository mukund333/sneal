using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] private int _maxHealth = 120;
	
	public Text healtText; 

    public int MaxHealth{
        get
        {
            return _maxHealth;
        }

        set
        {
            _maxHealth = Mathf.Clamp(value, 0, 3);
        }
    }

    public int Health{
        get
        {
            return _health;
        }

        set
        {
            _health = Mathf.Clamp(value,0,MaxHealth);
        }
    }

    private void OnValidate(){
        Health = _health;
        MaxHealth = _maxHealth;
    }
	
	void Start()
	{
		OnValidate();
		healtText.text  = "X "+Health.ToString();
	}
	
	void Update()
	{
		healtText.text  = "X "+Health.ToString();
	}
		
		
	
}
