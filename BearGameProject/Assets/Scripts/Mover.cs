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

    [SerializeField]
    private float m_maxForceMultiplier = 2.5f;
    [SerializeField]
    private float m_upAmount = 0.5f;
    //private AnimationCurve m_fallSpeedCurve;

    private float lengthBetween;

    private bool m_IsFalling = false;
    private bool m_IsMovingOnBelt = false;
    private bool m_HasReachedEnd = false;

    [SerializeField]
    private float m_PushMultiplier = 100.0f;

    [SerializeField]
    private Rigidbody m_RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(m_RigidBody, "No rigidbody attatched to the spawn object");
        m_RigidBody.useGravity = false;
        //m_fallSpeedCurve.postWrapMode = WrapMode.Loop;
        //m_fallSpeedCurve.preWrapMode = WrapMode.Loop;
        //lengthBetween = Vector3.Distance(transform.position, m_DropPoint.position);
        //Keyframe[] keys = m_fallSpeedCurve.keys;
        //Keyframe key = keys[1];
        //key.time = lengthBetween;
        //keys[1] = key;
        //m_fallSpeedCurve.keys = keys;
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
        //StartCoroutine(BearDropper());

        float distance = m_FallSpeed * Time.time;
        transform.position = Vector3.MoveTowards(transform.position, m_DropPoint.position, distance);
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, m_DropPoint.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            m_IsFalling = false;
            m_IsMovingOnBelt = true;
        }
    }

    //IEnumerator BearDropper()
    //{
    //    float dropTime = lengthBetween;
        
    //    //Vector3 startPos = transform.position;

    //    //transform.position = Vector3.Lerp(startPos, m_DropPoint.position, distance);

    //    yield return m_fallSpeedCurve.Evaluate(m_FallSpeed * m_fallSpeedCurve.Evaluate(Time.time));
    //}


    public void MoveConveyorBelt()
    {
        float distance = m_ConveyorBeltSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_EndPoint.position, distance);        

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, m_EndPoint.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            m_IsMovingOnBelt = false;
            m_RigidBody.useGravity = true;
            m_RigidBody.AddRelativeForce((transform.forward + (transform.up * m_upAmount)) * m_ConveyorBeltSpeed * m_PushMultiplier * Random.Range(1.0f, m_maxForceMultiplier));
        }
    }

    public void StartFalling()
    {
        m_IsFalling = true;
    }
}
