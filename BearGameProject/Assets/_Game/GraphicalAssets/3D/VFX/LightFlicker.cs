using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light[] allLights;
    public float topEffect = 500.0f;
    public float topRange = 0.1f;
    private int addForever = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Light light in allLights)
        {
            Random.InitState(addForever);

            addForever += 1;
            light.intensity = topEffect * Random.Range(0.0f, 1.0f);
            light.range = topRange * Random.Range(0.1f, 1.0f);
        }

        if(addForever > 45000)
        {
            addForever = 0;
        }
    }
}
