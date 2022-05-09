using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pers_Move : PersonalAct
{
    public int minSteps, maxSteps;

    public List<PersonalAttack>
        WhenLeave = new List<PersonalAttack>(),
        WhenEnter = new List<PersonalAttack>();

    public Pers_Move(MoveBase moveBase) : base(moveBase) {
        WhenLeave = moveBase.DefaultWhenLeave();
        WhenEnter = moveBase.DefaultWhenEnter();
    }
}