using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager : MonoBehaviour
{
    public Pool[] pools;

    private static PoolManager _instance;

	public void Awake()
	{
		for (int i = 0; i < this.pools.Length; i++)
		{
			GameObject gameObject = new GameObject();
			gameObject.name = this.pools[i].Name + " pool";
			gameObject.transform.parent = base.transform;
			this.pools[i].poolHolder = gameObject.transform;
			this.pools[i].id = i;
			for (int j = 0; j < this.pools[i].poolSize; j++)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pools[i].prefab, base.transform.position, Quaternion.identity);
				gameObject2.name = this.pools[i].Name;
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.SetActive(false);
				this.pools[i].pool.Add(gameObject2);
			}
		}
	}

	public static PoolManager instance
	{
		get
		{
			if(PoolManager._instance==null)
			{
				PoolManager._instance = FindObjectOfType<PoolManager>();
			}
			return PoolManager._instance;
		}
	}

	public GameObject GetObject(string poolName, Vector2 pos, Quaternion rot)
	{
		for (int i = 0; i < this.pools.Length; i++)
		{
			if (this.pools[i].Name == poolName)
			{
				for (int j = 0; j < this.pools[i].pool.Count; j++)
				{
					if (!this.pools[i].pool[j].activeInHierarchy)
					{
						GameObject gameObject = this.pools[i].pool[j];
						gameObject.transform.position = pos;
						gameObject.transform.rotation = rot;
						gameObject.SetActive(true);
						return gameObject;
					}
				}
				if (!this.pools[i].limit)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pools[i].prefab, pos, rot);
					gameObject2.name = this.pools[i].Name;
					gameObject2.transform.parent = this.pools[i].poolHolder;
					gameObject2.transform.position = pos;
					gameObject2.transform.rotation = rot;
					this.pools[i].pool.Add(gameObject2);
					return gameObject2;
				}
			}
		}
		return null;
	}

	public GameObject GetObject(int poolID, Vector2 pos, Quaternion rot)
	{
		for (int i = 0; i < this.pools[poolID].pool.Count; i++)
		{
			if (!this.pools[poolID].pool[i].activeInHierarchy)
			{
				GameObject gameObject = this.pools[poolID].pool[i];
				gameObject.transform.position = pos;
				gameObject.transform.rotation = rot;
				gameObject.SetActive(true);
				return gameObject;
			}
		}
		if (!this.pools[poolID].limit)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pools[poolID].prefab, pos, rot);
			gameObject2.name = this.pools[poolID].Name;
			gameObject2.transform.parent = this.pools[poolID].poolHolder;
			gameObject2.transform.position = pos;
			gameObject2.transform.rotation = rot;
			this.pools[poolID].pool.Add(gameObject2);
			return gameObject2;
		}
		return null;
	}

	public int GetPoolID(string poolName)
	{
		for (int i = 0; i < this.pools.Length; i++)
		{
			if (this.pools[i].Name == poolName)
			{
				return this.pools[i].id;
			}
		}
		return 0;
	}


	public void ReturnObjectToPool(GameObject obj)
	{
		obj.SetActive(false);
	}

}
