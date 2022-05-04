using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : ScriptableObject
{
    [SerializeField]
    List<B_ActBase>
        TurnStart = new List<B_ActBase>(),
        TurnEnd = new List<B_ActBase>(),
        WhenLeave = new List<B_ActBase>(),
        WhenEnter = new List<B_ActBase>();
}
