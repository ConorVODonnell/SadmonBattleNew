using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class B_Events{

    public static event Action<TerrainTA, CubeCoordinate> OnTerrainSet;
    public static void TerrainSet(TerrainTA terrainTA, CubeCoordinate newPos) {
        if (OnTerrainSet != null) OnTerrainSet(terrainTA, newPos);
    }

    public static event Action<SadeTA, CubeCoordinate> OnSademonLeavesTile;
    public static void SademonLeavesTile(SadeTA sadeTA, CubeCoordinate oldPos) {
        if (OnSademonLeavesTile != null) OnSademonLeavesTile(sadeTA, oldPos);
    }
    public static event Action<SadeTA, CubeCoordinate> OnSademonEntersTile;
    public static void SademonEntersTile(SadeTA sadeTA, CubeCoordinate newPos) {
        if (OnSademonEntersTile != null) OnSademonEntersTile(sadeTA, newPos);
    }
}
