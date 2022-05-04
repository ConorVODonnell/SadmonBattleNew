using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAct
{
    TileActor User;
    int strength;
    List<TileAct> Acts;
    CubeCoordinate startingGridPosition;

    public void Invoke() {
        foreach (var act in Acts) {
            var target = GetTarget(act);
            foreach (var effect in act.Effects) {
                effect.InvokeEffect(User, target, strength);
            }
        }
    }

    B_Tile GetTarget(TileAct act) {
        var worldLocation = User.WorldFromRelative(act.RelativeLocation);
        return LocationManager.Instance.GetTile(worldLocation);
    }
}
