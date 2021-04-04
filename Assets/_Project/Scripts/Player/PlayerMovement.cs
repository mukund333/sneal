using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private Vector2 direction;
        [SerializeField] private VirtualJoystick joystick;
        [SerializeField]
        private float turnRate = 8f;
		Rigidbody2D body2d;

        void Awake()
        {
			body2d = GetComponent<Rigidbody2D>();
            joystick = FindObjectOfType<VirtualJoystick>();
        }

        void Update()
        {
           
			
           
        }
		void FixedUpdate()
        {
			// direction = RoundVector3(PlayerInput());
			direction = new Vector2(joystick.Horizontal(), joystick.Vertical());
			Rotate();
		}
		

        private Vector2 PlayerInput()
        {
            return new Vector2(joystick.Horizontal(), joystick.Vertical());
        }

        private void Rotate()
        {
            if (Mathf.Abs(direction.x) > 0.05f || Mathf.Abs(direction.y) > 0.05f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
                Quaternion b = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
                transform.rotation = Quaternion.Slerp(transform.rotation, b, Time.fixedDeltaTime * turnRate);
            }
        }
		
		private static Vector3 RoundVector3( Vector3 v ) {
        return new Vector3((float)System.Math.Round(v.x,2), (float)System.Math.Round(v.y,2), (float)System.Math.Round(v.z,2) );
    }
    }
}