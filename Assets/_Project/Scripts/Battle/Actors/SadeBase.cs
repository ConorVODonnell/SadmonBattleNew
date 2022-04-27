using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewSademon", menuName = "Sademon/New Sademon")]
public class SadeBase : ScriptableObject
{
    [SerializeField] string sadeName;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] TileBase tile;

    [SerializeField] List<B_ActBase> learnableActs;

    // Properties
    public string Name => sadeName;
    public string Description => description;

    public TileBase Tile => tile;

    public List<B_ActBase> LearnableActs => learnableActs;
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

