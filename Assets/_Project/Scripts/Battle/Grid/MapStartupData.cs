using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMap", menuName = "Sademon/Grid/MapStartupData")]
public class MapStartupData : ScriptableObject
{
    [SerializeField] TerrainBase majority, supporting, blend, accent;


    [SerializeField] float supportingThreshold;
    [SerializeField] float blendThreshold;
    [SerializeField] float majorityThreshold;
    [SerializeField] float accentThreshold;

    [SerializeField] Gradient gradient;

    public float SupportingThreshold => supportingThreshold;
    public float BlendThreshold => blendThreshold;
    public float MajorityThreshold => majorityThreshold;
    public float AccentThreshold => accentThreshold;

    public TerrainBase DecideTerrain(float value) {
        if (value <= SupportingThreshold) return supporting;
        else if (value <= blendThreshold) return blend;
        else if (value <= majorityThreshold) return majority;
        else if (value <= accentThreshold) return accent;
        else throw new ArgumentOutOfRangeException();
    }
}
