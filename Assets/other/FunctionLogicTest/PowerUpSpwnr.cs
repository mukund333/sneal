using SnealUltra.Assets._Project.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpwnr : MonoBehaviour
{
	


    private float minRange = 8.0f;
	private float maxRange = 10.0f;
	
	public Transform target;

	public pwrStruct[] pwrlist;

	public GameObject obj;

	private float timer;
	private bool stopSpawn;
	public GameObject player;
	public Quaternion playerAxis;
	public bool testStartSpawn = false;

	private void Start()
	{
		player = GameObject.Find("Plyr");
	}

	private void Update()
	{
		if (testStartSpawn == true)
		{
			StartSpawning();
			GetPosition();
		}

		StopSpawning();
		//playerAxis = player.transform.rotation.ToAngleAxis();


	}

	private void StartSpawning()
	{
		this.stopSpawn = false;
		for (int i = 0; i < this.pwrlist.Length; i++)
		{
			base.StartCoroutine(this.SpawnPwrup(this.pwrlist[i]));
		}
		base.StartCoroutine(this.Timer());
	}

	private void StopSpawning()
	{
		this.stopSpawn = true;
	}

	private IEnumerator SpawnPwrup(pwrStruct gm)
	{
		float startedTime = this.timer;
		float startFrequency = gm.spawnFreqRange.x;
		float spawnFrequency = 0f;
		while (!stopSpawn && timer < gm.spawnStartTime)
		{
			yield return 0;
		}
		while (!this.stopSpawn)
		{
			Debug.Log(""+ GetPosition());
			Instantiate(obj, GetPosition(), Quaternion.identity);
			//PoolManager.instance.GetObject(enemy.poolId, (Vector2)this.player.position + UnityEngine.Random.insideUnitCircle.normalized * 300f, Quaternion.identity);
			spawnFrequency = Mathf.Lerp(startFrequency, gm.spawnFreqRange.y, gm.curve.Evaluate(Mathf.Lerp(0f, 1f, (this.timer - startedTime) / (float)gm.timeToMaxSpawnFreq)));
			MonoBehaviour.print(spawnFrequency);
			yield return new WaitForSeconds(1f / spawnFrequency);
		}
		yield break;
	}

	private IEnumerator Timer()
	{
		this.timer = 0f;
		while (!this.stopSpawn)
		{
			this.timer += Time.deltaTime;
			yield return 0;
		}
		this.timer = 0f;
		yield break;
	}



	public Vector3 GetPosition()
	{
		float randomRotation = UnityEngine.Random.Range(0.0f, 360.0f);
		float projection = minRange + UnityEngine.Random.Range(minRange, minRange +  (maxRange - minRange));
		// You could also try with Quaternion.Euler(0, angle, 0)...
		


		return Quaternion.AngleAxis(randomRotation, Vector3.forward) * Vector3.right * projection;
	}	
	
}
