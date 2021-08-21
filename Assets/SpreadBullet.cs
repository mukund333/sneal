using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBullet : MonoBehaviour
{
	Rigidbody2D body2d;
	[Header("Projectile Settings")]
	public int numberOfProjectiles;
	public float projectileSpeed =5f;
	public GameObject ProjectilePrefab;

   [Header("Projectile Settings")]
   private Vector2 startPoint;
   private const float radius = 5f;
   public float angle;
	
	


    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
		

    }

    // Update is called once per frame
    void Update()
    {
        //body2d.AddForce(-transform.right * bulletSpeed);
        if (Input.GetKeyDown(KeyCode.P))		
		{
			startPoint = transform.position;
			angle =  Random.Range(0, 44);
			SpawnProjectile(numberOfProjectiles);
		}

    }
	
	private void SpawnProjectile(int _numberOfProjectiles)
	{
		float angleStep = 360f / _numberOfProjectiles;
		 //angle = 10;
		
		for(int i =0 ; i <= _numberOfProjectiles-1;i++)
		{
			float projectileDirXPosition  = startPoint.x + Mathf.Sin((angle * Mathf.PI)/180)*radius;
			float projectileDirYPosition  = startPoint.y + Mathf.Cos((angle * Mathf.PI)/180)*radius;
			
			Vector2 projectileVector = new Vector2(projectileDirXPosition,projectileDirYPosition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;
			
			GameObject tmpObj = Instantiate(ProjectilePrefab,startPoint,Quaternion.identity);
			tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);
			
			angle += angleStep;
		}
	}
}
