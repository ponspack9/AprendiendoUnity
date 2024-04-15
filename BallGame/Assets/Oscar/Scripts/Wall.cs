using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float x = 0;
    public float z = 0;

    private float force = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.rigidbody.velocity;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(force * x,0.0f, force * z),ForceMode.Impulse);
    }
}
