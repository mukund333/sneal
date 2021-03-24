using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;


public class ItemSpawner : MonoBehaviour
{
	public bool debug;
	#region caching referance
		private Transform player;
	#endregion
	
	#region Unity Functions
			//#if UNITY_EDITOR
			//#endif
		private void Awake(){
			player = FindObjectOfType<PlayerMovement>().transform;
		}
		private void OnEnable(){
			Configure();
		}
		private void Start(){}	
		private void Update(){}
		private void FixedUpdate(){}
		private void OnDisable(){
			Dispose();
		}
			
	#endregion
	
	#region Public Functions
	#endregion
			
	#region Private Functions
	#endregion
	
	
	#region Logs

		private void Log(string _msg){
			if (!debug) return;
			Debug.Log("[MoocScript] :"+_msg);
		}

		private void LogWarning(string _msg){
			if (!debug) return;
			Debug.LogWarning("[MoocScript] :" +_msg);
		}
		
	#endregion
				
	#region Configure and Dispose
		private void Configure(){
			
		}
		private void Dispose(){}
	#endregion
		
}
