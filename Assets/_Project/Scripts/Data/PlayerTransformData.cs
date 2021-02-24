using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerTransformData", menuName = "PlayerTransformData",order =51)]
public class PlayerTransformData : ScriptableObject
{
    public Vector3 playerPosition;
    public Vector3 playerShootPoint;
    public Quaternion playerRotation;
}
