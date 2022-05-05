using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAffectShape", menuName = "Sademon/New Affect Shape Act")]
public class AffectShapeBase : B_ActBase
{
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
