using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour
{
    private Collider touchCollider;
    void Start()
    {
        touchCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
