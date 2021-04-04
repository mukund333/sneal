using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
		public static MyCameraController instance;

	public Transform target;
	public Vector3 targetPosition;
	public Vector2 JoystickVector;
	public Vector3 smoothDamp;
	public Transform myTransform;
	public int xOffset;
	public int yOffset;
	public Vector3 velocity = Vector3.zero;
	public float dampTime;

    void Start ()
    {
		MyCameraController.instance = this;

        myTransform = transform;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
		  targetPosition = target.TransformPoint(new Vector3(0, 0, -60));
		  
		  JoystickVector = new Vector2(VirtualJoystick.instance.Horizontal(), VirtualJoystick.instance.Vertical());
		  
		  smoothDamp = Vector3.SmoothDamp(myTransform.position, new Vector3(target.transform.position.x + (float)xOffset, target.transform.position.y + (float)yOffset, -10f), ref velocity, dampTime);
			
		  myTransform.position = new Vector3(smoothDamp.x + -JoystickVector.x, smoothDamp.y + -JoystickVector.y, -60);
		  
		  
		  
    }
}

















//float distance = Vector3.Distance (object1.transform.position, object2.transform.position);


	/*public GameObject player; //Public variable to store a reference to the player game object
    private Vector3 offset; //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start ()
    {
        //Calculate and store the offset value by getting the distance between
        // the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        // Set the position of the camera's transform to be the same as
        // the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }*/