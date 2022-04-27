using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAct
{
    TileActor User;
    int strength;
    List<TileAct> Acts;

    public void Invoke() {
        foreach (var act in Acts) {
            foreach (var effect in act.Effects) {
                var target = GetTarget(act);
                effect.InvokeEffect(User, target, strength);
            }
        }
    }

    B_Tile GetTarget(TileAct act) {
        var worldLocation = User.WorldFromRelative(act.RelativeLocation);
        return LocationManager.Instance.GetTile(worldLocation);
    }
}
