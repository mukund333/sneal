using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        private Vector2 direction;
        [SerializeField] private VirtualJoystick joystick;
        [SerializeField]
        private float turnRate = 8f;


        void Awake()
        {
            joystick = FindObjectOfType<VirtualJoystick>();
        }

        void FixedUpdate()
        {
            direction = PlayerInput();
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
    }
}