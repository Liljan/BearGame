using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsTouchingConveyour : MonoBehaviour
{
    [SerializeField]
    private float upForce = 0.2f;

    [SerializeField]
    private float forwardForce = 10000.0f;

    private Collider touchCollider;
    void Start()
    {
        touchCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag ==  "Arm" || other.gameObject.tag == "Leg" || other.gameObject.tag == "Head")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward + (Vector3.up * upForce) * forwardForce, ForceMode.Impulse);
        }
    }
}
