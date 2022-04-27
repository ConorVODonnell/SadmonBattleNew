using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sademon
{
    public string Name { get; set; }
    public SadeBase Base { get; private set; }

    public void Init(SadeBase _base) {
        Base = _base;
        Name = Base.Name;
    }

    List<B_ActConstructor> DefaultActs() {
        var defaultActs = new List<B_ActConstructor>();

        foreach (var learnable in Base.LearnableActs) {
            var newConstructor = new B_ActConstructor(learnable);
        }

        return defaultActs;
    }

}
