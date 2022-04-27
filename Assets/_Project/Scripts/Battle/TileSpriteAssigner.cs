using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpriteAssigner : MonoBehaviour
{
    [SerializeField] Tilemap ground, sademon, highlight;

    void OnEnable() {
        B_Events.OnTerrainSet += SetTerrain;
        B_Events.OnSademonEntersTile += AddSademon;
        B_Events.OnSademonLeavesTile += RemoveSademon;
    }

    void OnDisable() {
        B_Events.OnTerrainSet -= SetTerrain;
        B_Events.OnSademonEntersTile -= AddSademon;
        B_Events.OnSademonLeavesTile -= RemoveSademon;
    }

    void SetTerrain(TerrainTA terrainTA, CubeCoordinate newPos) {
        ground.SetTile(newPos.ToGrid(), terrainTA.Tile);
    }

    void RemoveSademon(SadeTA sadeTA, CubeCoordinate oldPos) {
        sademon.SetTile(oldPos.ToGrid(), null);
    }

    void AddSademon(SadeTA sadeTA, CubeCoordinate newPos) {
        sademon.SetTile(newPos.ToGrid(), sadeTA.Tile);
    }
}
