using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewMove", menuName = "Sademon/New Action")]
public abstract class B_ActBase : ScriptableObject
{
    [SerializeField] string moveName;

    [TextArea]
    [SerializeField] string description;

    public string Name { get { return moveName; } }
    public string Description { get { return description; } }
}
