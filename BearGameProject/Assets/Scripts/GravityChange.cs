using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField]
    private float gravityAmount = 0.5f;

    private Rigidbody gravBody;
    void Start()
    {
        gravBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravBody.AddForce(Physics.gravity * gravityAmount);
    }
}
