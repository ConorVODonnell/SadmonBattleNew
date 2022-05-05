using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pers_CreateProjectile : PersonalAct
{
    class PersonalProjectile
    {
        ProjectileBase Base;

        public PersonalProjectile(ProjectileBase @base) {
            Base = @base;
        }
    }
}
