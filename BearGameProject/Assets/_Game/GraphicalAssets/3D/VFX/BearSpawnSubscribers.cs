using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawnSubscribers : MonoBehaviour
{
    public GameObject spawnLight;
    public float bearLightTime = 0.15f;
    public float bearFailOfScoreTime = 0.15f;

    //Standard
    [ColorUsageAttribute(false,true)]
    public Color baseColor = new Color(4.0f, 4.0f, 4.0f, 1.0f);
    public Color baseLightColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public float baseLightIntensity = 6000.0f;

    //Attached part
    public AudioClip attachedPart;

    //Scored
    [ColorUsageAttribute(false,true)]
    public Color scoreColor = new Color(1.6f, 16.0f, 0.0f, 1.0f);
    public Color scoreLightColor = new Color(0.05f, 1.0f, 0.0f, 1.0f);
    public float scoreLightIntensity = 18000.0f;
    public AudioClip scoredClip;

    //Failed
    [ColorUsageAttribute(false,true)]
    public Color failColor = new Color(25.6f, 0.0f, 0.0f, 1.0f);
    public Color failLightColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    public float failLightIntensity = 18000.0f;
    public AudioClip failedClip;

    public GameObject warningLight;
    private Material warningLightMaterial;
    public Light warningLightLight;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        warningLightMaterial = warningLight.GetComponent<Renderer>().materials[1];
        EventManager.StartListening("BearSpawn", BearHasSpawned);
        EventManager.StartListening("BearScore", BearPoint);
        EventManager.StartListening("BearFailed", BearNoPoint);
        EventManager.StartListening("PartAttach", AttachPart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
            EventManager.TriggerEvent("BearScore");
        if (Input.GetKeyDown("o"))
            EventManager.TriggerEvent("BearFailed");
        if (Input.GetKeyDown("p"))
            EventManager.TriggerEvent("ParthAttach");
    }

    void AttachPart()
    {
        audioPlayer.PlayOneShot(attachedPart);
    }


    void BearHasSpawned()
    {
        StartCoroutine(BearLight());
    }

    IEnumerator BearLight()
    {
        spawnLight.SetActive(true);
        yield return new WaitForSeconds(bearLightTime);
        spawnLight.SetActive(false);
    }

    void BearNoPoint()
    {
        StartCoroutine(BearFailedOrScored(false));
    }

    void BearPoint()
    {
        StartCoroutine(BearFailedOrScored(true));
    }

    IEnumerator BearFailedOrScored(bool scored)
    {
        Color color = baseColor;
        Color lightColor = baseLightColor;
        float intensity = baseLightIntensity;
        if(scored)
        {
            color = scoreColor;
            lightColor = scoreLightColor;
            intensity = scoreLightIntensity;
            audioPlayer.PlayOneShot(scoredClip);
        }
        else
        {
            color = failColor;
            lightColor = failLightColor;
            intensity = failLightIntensity;
            audioPlayer.PlayOneShot(failedClip);

        }
        warningLightMaterial.SetColor("_WarningColor", color);
        warningLightLight.intensity = intensity;
        warningLightLight.color = lightColor;

        yield return new WaitForSeconds(bearFailOfScoreTime);
        color = baseColor;
        lightColor = baseLightColor;
        warningLightLight.color = baseLightColor;
        warningLightLight.intensity = baseLightIntensity;

        warningLightMaterial.SetColor("_WarningColor", color);
    }
}
