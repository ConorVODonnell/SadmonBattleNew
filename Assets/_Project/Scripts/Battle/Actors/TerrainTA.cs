using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainTA : TileActor
{
    public TerrainBase Base { get; private set; }

    public override TileBase Tile { get { return Base.Tile; } }

    public TerrainTA(TerrainBase terrainBase, CubeCoordinate location) {
        Base = terrainBase;
        Location = location;
    }

    public override void MoveTo(CubeCoordinate newLocation) {
        throw new System.NotImplementedException();
    }
}
