using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCreateProjectileAct", menuName = "Sademon/New Create Projectile Act")]
public class CreateProjectileBase : B_ActBase
{
    public override PersonalAct DefaultAct() {
        return new Pers_CreateProjectile();
    }
}
