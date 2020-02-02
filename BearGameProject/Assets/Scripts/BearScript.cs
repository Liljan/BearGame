﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    public GameObject Head;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject LeftLeg;
    public GameObject RightLeg;

    void SetupBearParameters(bool showHead, bool showLeftArm, bool showRightArm, bool showLeftLeg, bool showRightLeg)
    {
        if(Head != null)
        {
            Head.SetActive(showHead);
        }

        if (LeftArm != null)
        {
            LeftArm.SetActive(showLeftArm);
        }

        if (RightArm != null)
        {
            RightArm.SetActive(showRightArm);
        }


        if (LeftLeg != null)
        {
            LeftLeg.SetActive(showRightLeg);
        }

        if (RightLeg != null)
        {
            RightLeg.SetActive(RightLeg);
        }
    }

    public bool IsBearCompleted()
    {
        return Head.activeSelf && LeftArm.activeSelf && RightArm.activeSelf && LeftLeg.activeSelf && RightLeg.activeSelf;
    }

    bool TryAddArm()
    {
        if(!RightArm.activeSelf)
        {
            RightArm.SetActive(true);
            return true;
        }
        
        if(!LeftArm.activeSelf)
        {
            LeftArm.SetActive(true);
            return true;
        }

        return false;
    }

    bool TryAddLeg()
    {
        if (!LeftLeg.activeSelf)
        {
            LeftLeg.SetActive(true);
            return true;
        }

        if (!RightLeg.activeSelf)
        {
            RightLeg.SetActive(true);
            return true;
        }

        return false;
    }

    bool TryAddHead()
    {
        if (!Head.activeSelf)
        {
            Head.SetActive(true);
            return true;
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Leg")
        {
            if (TryAddLeg())
            {
                Debug.Log("Consume leg");
                Destroy(other.gameObject);
            }
        }

        else if (other.tag == "Arm")
        {
            if (TryAddArm())
            {
                Debug.Log("Consume Arm");
                Destroy(other.gameObject);
            }
        }

        else if (other.tag == "Head")
        {
            if (TryAddHead())
            {
                Debug.Log("Consume Head");
                Destroy(other.gameObject);
            }
        }

    }
}
