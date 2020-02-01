using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Transform m_StartPoint;
    private Transform m_DropPoint;
    private Transform m_EndPoint;

    [SerializeField]
    private float m_FallSpeed;
    [SerializeField]
    private float m_ConveyorBeltSpeed;

    private bool m_IsFalling = false;
    private bool m_IsMovingOnBelt = false;
    private bool m_HasReachedEnd = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsFalling)
            MoveFalling();
        else if(m_IsMovingOnBelt)
            MoveConveyorBelt();
    }

    public void SetStartPoint(Transform t)
    {
        m_StartPoint = t;
    }

    public void SetDropPoint(Transform t)
    {
        m_DropPoint = t;
    }

    public void SetEndPoint(Transform t)
    {
        m_EndPoint = t;
    }

    public void MoveFalling()
    {
        float distance = m_FallSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_DropPoint.position, distance);

        // Check if the position of the cube and sphere are approximately equal.
        if(Vector3.Distance(transform.position, m_DropPoint.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            m_IsFalling = false;
            m_IsMovingOnBelt = true;  
        }
    }


    public void MoveConveyorBelt()
    {
        float distance = m_ConveyorBeltSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_EndPoint.position, distance);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, m_EndPoint.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            m_IsMovingOnBelt = false;
        }
    }

    public void StartFalling()
    {
        m_IsFalling = true;
    }
}
