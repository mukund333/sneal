using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCameraFollowSmooth : MonoBehaviour
{
	public Transform target;
    public float smoothTime = 0.3F;
    public Vector3 velocity = Vector3.zero;
	public Vector2 JoystickVector;
	public Vector3 smoothDamp;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -60));
		
		JoystickVector = new Vector2(VirtualJoystick.instance.Horizontal(), VirtualJoystick.instance.Vertical());
		
        // Smoothly move the camera towards that target position
		  smoothDamp = Vector3.SmoothDamp(transform.position, new Vector3(target.transform.position.x , target.transform.position.y , -10f), ref velocity, smoothTime);
		
		  transform.position = new Vector3(smoothDamp.x + -JoystickVector.x, smoothDamp.y + -JoystickVector.y, -60);
    }
}
