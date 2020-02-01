using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
