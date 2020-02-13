using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawnOnClick : MonoBehaviour
{
    public Spawner spawner;
    public Material materialOnClick;

    [ColorUsage(true, true)]
    public Color blinkToColor;
    private Color startColor;


    private void Start()
    {
        startColor = materialOnClick.GetColor("_WarningColor");
    }

    private void OnMouseDown()
    {
        Spawn();
        materialOnClick.SetColor("_WarningColor", blinkToColor);
    }

    private void OnMouseUp()
    {
        materialOnClick.SetColor("_WarningColor", startColor);
    }

    void Spawn()
    {
        spawner.SpawnObjects();
    }
}
