using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewMove", menuName = "Sademon/New Action")]
public abstract class B_ActBase : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    public abstract PersonalAct DefaultAct();
}
