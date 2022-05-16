using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pers_AffectShape : PersonalAttack
{
    public Pers_AffectShape(AffectShapeBase affectShapeBase) : base(affectShapeBase) {

    }

    public override void AttackTile(CubeCoordinate centerOfAttack) {
        throw new System.NotImplementedException();
    }
}