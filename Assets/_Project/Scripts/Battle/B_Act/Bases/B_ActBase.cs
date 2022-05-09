using System.Collections.Generic;
using UnityEngine;

public abstract class B_ActBase : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    public abstract PersonalAct DefaultPersonal();

    public static List<PersonalAct> DefaultPersonalList(List<B_ActBase> baseList) {
        var defaultList = new List<PersonalAct>();
        if (baseList == null || baseList.Count == 0) return defaultList;
        foreach (var baseAct in baseList)
            defaultList.Add(baseAct.DefaultPersonal());
        return defaultList;
    }

    public static List<PersonalAttack> DefaultAtackList(List<B_AttackBase> baseList) {
        var defaultList = new List<PersonalAttack>();
        if (baseList == null || baseList.Count == 0) return defaultList;
        foreach (var baseAttack in baseList)
            defaultList.Add(baseAttack.DefaultAttack());
        return defaultList;
    }
}