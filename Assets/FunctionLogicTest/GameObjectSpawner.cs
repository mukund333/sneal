using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    
    public float minRadius = 3f;
    public float maxRadius = 7f;
    public int pointAmount = 100;
    public GameObject prefab;
    public GameObject player;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    


    void Start()
    {
        player = GameObject.Find("Plyr");

        InvokeRepeating("PowerUpSpawn", spawnTime, spawnDelay);
        
    }

    public void PowerUpSpawn()
    {
        if (player != null && stopSpawning == false)
        {
                for (int i = 0; i < pointAmount; i++)
                {
                    var pointToSpawnAt = RandomPointInAnnulus(player.transform.position, minRadius, maxRadius);

                    Instantiate(prefab, pointToSpawnAt, prefab.transform.rotation);
                }     
        }

        if (stopSpawning)
        {
            CancelInvoke("PowerUpSpawn");
        }
    }
    public Vector2 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {

        var randomDirection = (Random.insideUnitCircle * origin).normalized;

        var randomDistance = Random.Range(minRadius, maxRadius);

        var point = origin + randomDirection * randomDistance;

        return point;
    }
}
