using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Tile
{
    public CubeCoordinate Location {
        get {
            return Contents.Terrain.Location;
        }
    }
    public readonly TileContents Contents;

    #region ContentsFascade
    public B_Tile(TerrainTA terrainTA) => Contents = new TileContents(terrainTA);
    public List<TileActor> GetOccupants() => Contents.GetOccupants();
    public void AddSademon(SadeTA sade) => Contents.AddSademon(sade);
    public SadeTA RemoveSademon() => Contents.RemoveSademon();
    public TerrainTA SwitchTerrain(TerrainTA newTerrain) => Contents.SwitchTerrain(newTerrain);
    #endregion

    public bool HasSademon(out SadeTA sademon) {
        sademon = Contents.Sademon;
        return (sademon != null);
    }
}
