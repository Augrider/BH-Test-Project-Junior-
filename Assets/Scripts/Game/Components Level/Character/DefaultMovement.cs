using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : IMovement
{
    private Rigidbody rigidbody;


    public DefaultMovement(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }


    public void SetSpeed(Vector3 value)
    {
        rigidbody.velocity = value;
    }

    public void AddImpulse(Vector3 direction, float strength)
    {
        rigidbody.AddForce(direction * strength, ForceMode.Impulse);
    }
}
