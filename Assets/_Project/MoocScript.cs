using UnityEngine;


//core namespace
namespace UnityCore{
	//section namespace like Audio,Enemy etc
	namespace MoocNamespsce{
	
		public class MoocScript : MonoBehaviour
		{
			public bool debug;
			
			#region caching referance params
			
			#endregion
			
			#region Unity Functions
			//#if UNITY_EDITOR
			//#endif
				private void Awake(){
					//caching component here
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
				private void Configure(){}
				private void Dispose(){}
			#endregion
		
		}
	}
}

