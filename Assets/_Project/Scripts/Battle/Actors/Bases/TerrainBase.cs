using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTerrain", menuName = "Sademon/Grid/Terrain")]
public class TerrainBase : ScriptableObject
{
	[SerializeField] TileBase tile;
	[SerializeField] TerrainType terrainType;

    public TileBase Tile => tile;
    public TerrainType TerrainType => terrainType;
}

    public enum TerrainType
{
	Grass,
	Sand,
	Stone,
	Swamp,
	Water
}
