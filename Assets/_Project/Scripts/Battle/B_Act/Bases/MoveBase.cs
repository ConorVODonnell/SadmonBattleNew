using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBase : B_ActBase
{
    [field: SerializeField] public List<B_AttackBase> WhenLeave { get; private set; }
    [field: SerializeField] public List<B_AttackBase> WhenEnter { get; private set; }

    public override PersonalAct DefaultPersonal() {
        var move = new Pers_Move(this);

        return move;
    }

    public List<PersonalAttack> DefaultWhenLeave() {
        return DefaultAtackList(WhenLeave);
    }
    public List<PersonalAttack> DefaultWhenEnter() {
        return DefaultAtackList(WhenEnter);
    }
}