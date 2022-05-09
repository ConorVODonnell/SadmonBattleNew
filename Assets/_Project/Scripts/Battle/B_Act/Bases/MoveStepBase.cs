using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Sademon/Move Step")]
public class MoveStepBase : MoveBase
{
    public override PersonalAct DefaultPersonal() {
        var move = (Pers_Move)base.DefaultPersonal();

        ModifyPers_Move(move);

        return move;
    }

    void ModifyPers_Move(Pers_Move move) {
        move.minSteps = 1;
        move.maxSteps = 1;
    }
}