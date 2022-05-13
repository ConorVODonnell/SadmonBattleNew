using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlan : ActPlan
{
    public void PerformAction() {
        PerformMove();
    }

    void PerformMove() {
        if (User is not IMoveable) throw new System.Exception("User of action cannot move.");

        LeavingAttacks();
        TakeAStep();
        EnteringAttacks();
    }

    void EnteringAttacks() {
        foreach (var attack in ((Pers_Move)Act).WhenEnter) {
            attack.AttackTile(User.Location);
        }
    }

    void TakeAStep() {
        User.MoveTo(Path.Dequeue());
        if (Path.Count == 0)
            PlanCompleted = true;
    }

    void LeavingAttacks() {
        foreach (var attack in ((Pers_Move)Act).WhenLeave) {
            attack.AttackTile(User.Location);
        }
    }
}