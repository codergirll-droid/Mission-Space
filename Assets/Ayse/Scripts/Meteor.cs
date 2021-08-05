using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float minSpeed = 0.001f;
    public float maxSpeed = 0.005f;

    private void FixedUpdate()
    {
        transform.position += Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.fixedDeltaTime;
        rotateAround();
    }

    void rotateAround()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Random.Range(20, 40));

    }

}
