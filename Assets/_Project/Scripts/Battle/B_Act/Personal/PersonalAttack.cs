using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonalAttack : PersonalAct
{
    protected PersonalAttack(B_AttackBase battleAttackBase) : base(battleAttackBase) {
    }

    public abstract void AttackTile(CubeCoordinate centerOfAttack);
}