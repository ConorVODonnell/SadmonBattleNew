using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProjectileTA : TileActor
{
    Queue<Vector3> Path;

    public override TileBase Tile => throw new System.NotImplementedException();

    public override void MoveTo(CubeCoordinate newLocation) {
        throw new System.NotImplementedException();
    }
}
