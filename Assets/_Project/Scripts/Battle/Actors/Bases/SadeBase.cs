using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewSademon", menuName = "Sademon/New Sademon")]
public class SadeBase : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    [field: SerializeField] public TileBase Tile { get; private set; }

    [field: SerializeField] public MoveBase Move { get; private set; }
    [field: SerializeField] public List<B_ActBase> LearnableActs { get; private set; }
}

public enum SademonType
{
    None,
    Normal,
    Fire,
    Water,
    Grass,
    Electric,
    Rock,
    Poison,
}