using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	
	public CameraFollow cameraFollow;
	public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(()=> player.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
