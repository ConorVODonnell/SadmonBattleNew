using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ActConstructor
{
    public B_ActBase Base { get; }

    public B_ActConstructor(B_ActBase @base) {
        Base = @base;
    }
}
