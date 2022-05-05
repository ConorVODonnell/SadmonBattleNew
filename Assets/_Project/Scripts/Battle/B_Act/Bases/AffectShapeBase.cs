using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAffectShape", menuName = "Sademon/New Affect Shape Act")]
public class AffectShapeBase : B_ActBase
{
    [SerializeField]
    B_ActShape shape;

    public B_ActShape Shape { get { return shape; } }

    public override PersonalAct DefaultAct() {
        return new Pers_AffectShape();
    }
}
