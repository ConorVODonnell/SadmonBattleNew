using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewMove", menuName = "Sademon/New Action")]
public class B_ActBase : ScriptableObject
{
    [SerializeField] string moveName;

    [TextArea]
    [SerializeField] string description;

    public string Name { get { return moveName; } }
    public string Description { get { return description; } }

    [SerializeField]
    List<MoveEffect>
        OnPrimary = new List<MoveEffect>(),
        OnSplitPrime = new List<MoveEffect>(),
        OnSecondary = new List<MoveEffect>(),
        OnTertiary = new List<MoveEffect>();

    [SerializeField]
    B_ActShape shape;

    public B_ActShape Shape { get { return shape; } }
}
