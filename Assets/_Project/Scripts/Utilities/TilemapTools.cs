using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapTools
{
    public static List<CubeCoordinate> CubeCoordinatesInMapCube(Tilemap map) {
        var cellsInMap = new List<CubeCoordinate>();

        foreach (var cell in V3IntInMap(map)) {
            cellsInMap.Add(CubeCoordinate.ToCube(cell));
        }

        return cellsInMap;
    }

    public static List<Vector3Int> V3IntInMap(Tilemap map) {
        var cellsInMap = new List<Vector3Int>();

        map.CompressBounds();
        Vector3Int pos = Vector3Int.zero;
        Vector3Int botLeft = map.origin;
        Vector3Int topRight = botLeft + map.size;
        for (int x = botLeft.x; x < topRight.x; x++) {
            for (int y = botLeft.y; y < topRight.y; y++) {
                pos.x = x;
                pos.y = y;

                if (map.HasTile(pos))
                    cellsInMap.Add(pos);
            }
        }

        return cellsInMap;
    }
}