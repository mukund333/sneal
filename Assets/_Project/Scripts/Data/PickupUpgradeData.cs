using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PickupUpgradeData", menuName = "PickupUpgradeData")]
public class PickupUpgradeData : ScriptableObject
{
    [SerializeField] int _playerHealth = 3;
    [SerializeField] private int _playerMaxHealth = 3;
	
	[SerializeField] private int        _shieldHealth;
    [SerializeField] private int        _maxShieldHealth;

    [SerializeField] private float      _shieldTime;
	[SerializeField] private float      _shieldMaxTime;
    
	
	
    public int PlayerHealth{
        get
        {
            return _playerHealth;
        }

        set
        {
            _playerHealth = Mathf.Clamp(value,1,MaxPlayerHealth);
        }
    }

	public int MaxPlayerHealth
	{
        get
        {
            return _playerMaxHealth;
        }

        set
        {
            _playerMaxHealth = Mathf.Clamp(value,3,10);
        }
    }

	
	public int SheildHealth
    {
        get
        {
            return _shieldHealth;
        }

        set
        {
            _shieldHealth = Mathf.Clamp(value, 0, _maxShieldHealth);
        }
    }
	
	
	
	public float SheildTime
    {
        get
        {
            return _shieldTime;
        }

        set
        {
            _shieldTime = Mathf.Clamp(value, 0, _shieldMaxTime);
        }
    }
	
	private void OnValidate(){
        PlayerHealth = _playerHealth;
        SheildHealth = _shieldHealth;
		SheildTime = _shieldTime;
   
    }
	
	
	
}
