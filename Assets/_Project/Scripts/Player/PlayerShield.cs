using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    /*
			- shield health
			- shield time duration
			- shield sprite
			- when it on ,player health not effected
			
   */

    
    [SerializeField] private int        _shieldHealth;
    [SerializeField] private int        _maxShieldHealth;

    [SerializeField] private float      shieldTime;
    [SerializeField] private GameObject shieldSprite;
    [SerializeField] private AbilityUI abilityUI;

    public bool IsShieldOn;

    public int MaxSheildHealth
    {
        get
        {
            return _maxShieldHealth;
        }

        set
        {
            _maxShieldHealth = Mathf.Clamp(value, 0, 200);
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
            _shieldHealth = Mathf.Clamp(value, 0, MaxSheildHealth);
        }
    }

    private void OnValidate()
    {
        SheildHealth = _shieldHealth;
        MaxSheildHealth = _maxShieldHealth;
    }

    private void OnEnable()
    {
        IsShieldOn = true;
    }

    void Start()
    {
        OnValidate();
        shieldSprite =   this.transform.Find("ShieldSprites").gameObject;
        abilityUI = FindObjectOfType<AbilityUI>();
    }

    void Update()
    {
        if (IsShieldOn)
            SheildDuration();



        if (SheildHealth <= 0)
            ShieldDisable();

        ShieldAnimation();

    }

    private void ShieldAnimation()
    { 
        if(IsShieldOn)
            shieldSprite.SetActive(true);
        else
            shieldSprite.SetActive(false);
    }

    private void SheildDuration()
    {
        shieldTime -= Time.deltaTime;
        abilityUI.ChangeTimeText(shieldTime);
        abilityUI.ChangeAbilityColorUI(Color.green);
        if (shieldTime <= 0)
        {
            abilityUI.ChangeTimeText(0);
            abilityUI.ChangeAbilityColorUI(Color.white);
            ShieldDisable();
        }

    }

    public void DamageToShield(int damageAmount)
    {
        SheildHealth -= damageAmount;
    }

    private void ShieldDisable()
    {

        IsShieldOn = false;
        this.enabled = false;
    }

    // reset the values time and damage
    private void OnDisable()
    {
        shieldTime = 30f;
        SheildHealth = 10;
       
    }

}
