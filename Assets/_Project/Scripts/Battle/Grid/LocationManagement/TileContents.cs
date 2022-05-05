using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Everything about what's on a tile
public class TileContents
{
    readonly CubeCoordinate Location;

    public TerrainTA Terrain;
#nullable enable
    public SadeTA? Sademon;
#nullable disable

    bool hasChanged;
    List<TileActor> AllOccupants = new List<TileActor>();

    public TileContents(TerrainTA terrain) {
        Location = terrain.Location;
        SwitchTerrain(terrain);
        AllOccupants.Add(terrain);
    }

    public List<TileActor> GetOccupants() {
        ValidateAllOccupants();
        return AllOccupants;
    }

    public TerrainTA SwitchTerrain(TerrainTA newTerrain) {
        var oldTerrain = Terrain;
        Terrain = newTerrain;

        B_Events.TerrainSet(newTerrain, Location);
        ChangedContents();
        return oldTerrain;
    }

    public void AddSademon(SadeTA newSade) {
        Sademon = newSade;

        B_Events.SademonEntersTile(newSade, Location);
        ChangedContents();
    }

    public SadeTA RemoveSademon() {
        SadeTA oldSade = null;

        if (Sademon is not null) {
            oldSade = Sademon;
            Sademon = null;

            B_Events.SademonLeavesTile(oldSade, Location);
            ChangedContents();
        }

        return oldSade;
    }

    void ValidateAllOccupants() {
        if (hasChanged) ReAddAllToList();
        hasChanged = false;
    }

    void ReAddAllToList() {
        AllOccupants.Clear();
        AllOccupants.Add(Terrain);
        if (Sademon is not null) AllOccupants.Add(Sademon);
    }

    void ChangedContents() {
        hasChanged = true;
    }
}
