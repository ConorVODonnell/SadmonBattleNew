

public abstract class B_AttackBase : B_ActBase
{
    public override PersonalAct DefaultPersonal() {
        return DefaultAttack();
    }
    public abstract PersonalAttack DefaultAttack();
}