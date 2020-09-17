using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct Pool
{
	
	public string Name;

	
	public int id;

	
	public GameObject prefab;

	
	public int poolSize;

	
	public bool limit;

	
	public Transform poolHolder;

	
	public List<GameObject> pool;
}
