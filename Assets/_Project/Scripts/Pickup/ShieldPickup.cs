using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Pickup;
using SnealUltra.Assets._Project.Scripts.Player;

[RequireComponent(typeof(Collider2D))]
public class ShieldPickup : Pickup
{
    public PickupData thisPickup;

    [SerializeField] private PlayerShield playerShield;
    [SerializeField] private float targetDistance;

    private void OnEnable()
    {
        InitPickup();
    }

    private void Awake()
    {
        playerShield = FindObjectOfType<PlayerShield>();
        
    }

    private void Update()
    {
        DisableReapair();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            playerShield.enabled = true;

            gameObject.SetActive(false);
        }
    }

    public void DisableReapair()
    {
        targetDistance = Vector3.Distance(this.transform.position, playerShield.transform.position);

        if (targetDistance > 20)
        {
            gameObject.SetActive(false);
        }
    }

    private void InitPickup()
    {

        thisPickup = PickupDatabase.instance.GetPickupByName("Shield");
    }

   

    public override string GetPowerUpName()
    {
        return thisPickup.Name;
    }

    public void SetPowerUpPoolId(int poolid)
    {

        thisPickup.poolId = poolid;
    }

    public override int GetPoolId()
    {
        return thisPickup.poolId;
    }


    public override AnimationCurve GetCurve()
    {
        return thisPickup.curve;
    }

    public override int GetMaxFreq()
    {
        return thisPickup.timeToMaxSpawnFreq;
    }

   

    public override Vector2 GetSpawnFreqRange()
    {
        return thisPickup.spawnFreqRange;
    }

    public override int GetSpawnStartTime()
    {
        return thisPickup.spawnStartTime;
    }
}
