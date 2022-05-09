using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalAct
{
    public string Name { get; protected set; }
    B_ActBase @base;

    public PersonalAct(B_ActBase b_ActBase) {
        Name = b_ActBase.Name;
        @base = b_ActBase;
    }
}