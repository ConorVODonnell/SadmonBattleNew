using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SadeTA : TileActor, IDamageable
{
    public Sademon Sademon;

    public bool isPlayer;

    public override TileBase Tile => Sademon.Base.Tile;

    public SadeTA(Sademon sademon) {
        Sademon = sademon;
        Name = Sademon.Base.Name;
    }

    public SadeTA(SadeBase sademonBase) {
        var sade = new Sademon();
        sade.Init(sademonBase);

        Sademon = sade;
        Name = sademonBase.Name;
    }

    public override void MoveTo(CubeCoordinate newLocation) {
        var map = LocationManager.Instance;
        // Remove from old
        map.GetTile(Location).RemoveSademon();

        // Add to new
        map.GetTile(newLocation).AddSademon(this);
    }

    public void TakeDamage(int damage) {
        Debug.Log($"{Sademon.Name} took {damage} damage.");
    }
}
