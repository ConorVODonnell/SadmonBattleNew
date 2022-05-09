using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCreateProjectileAct", menuName = "Sademon/Create Projectile Act")]
public class CreateProjectileBase : B_AttackBase
{
    public override PersonalAttack DefaultAttack() {
        var createProjectile = new Pers_CreateProjectile(this);

        return createProjectile;
    }
}