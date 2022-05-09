using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAffectShape", menuName = "Sademon/Affect Shape Act")]
public class AffectShapeBase : B_AttackBase
{
    [field: SerializeField] public B_ActShape Shape { get; protected set; }

    public override PersonalAttack DefaultAttack() {
        var affectShape = new Pers_AffectShape(this);

        return affectShape;
    }
}