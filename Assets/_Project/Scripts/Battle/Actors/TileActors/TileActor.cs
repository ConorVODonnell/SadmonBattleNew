using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileActor
{
    public string Name { get; protected set; }
    public CubeCoordinate Location { get; protected set; }
    public abstract UnityEngine.Tilemaps.TileBase Tile { get; }

    public bool Remains { get; private set; } = true;

    public CubeCoordinate WorldFromRelative(CubeCoordinate relativePosition) {
        return Location + relativePosition;
    }

    public abstract void MoveTo(CubeCoordinate newLocation);
}
