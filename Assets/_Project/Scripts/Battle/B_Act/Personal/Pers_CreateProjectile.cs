using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pers_CreateProjectile : PersonalAttack
{
    public int minRange = 1, maxRange = 2;

    public Pers_CreateProjectile(CreateProjectileBase createProjectileBase) : base(createProjectileBase) {

    }

    public override void AttackTile(CubeCoordinate centerOfAttack) {
        throw new System.NotImplementedException();
    }

    class PersonalProjectile
    {
        ProjectileBase Base;

        public PersonalProjectile(ProjectileBase projectileBase) {
            Base = projectileBase;
            
        }
    }
}