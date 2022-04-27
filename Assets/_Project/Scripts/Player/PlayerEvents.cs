using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action<B_Tile> OnTileSelected;
    public static void TileSelected(B_Tile tile) {
        if (OnTileSelected != null) OnTileSelected(tile);
    }
}
