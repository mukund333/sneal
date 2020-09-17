using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocitytest : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int forceSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        forceSpeed = CheckVelocityMagnitude();
    }
    private int CheckVelocityMagnitude()
    {
        return (int)rb2d.velocity.magnitude;
    }
}
