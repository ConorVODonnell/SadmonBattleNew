using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMoveAct", menuName = "Sademon/New Move Act")]
public class MoveBase : B_ActBase
{
    [SerializeField]
    int minDist, maxDist;

    [SerializeField]
    List<B_ActBase>
        WhenLeave = new List<B_ActBase>(),
        WhenEnter = new List<B_ActBase>();

    public override PersonalAct DefaultAct() {
        return new Pers_Move();
    }
}
