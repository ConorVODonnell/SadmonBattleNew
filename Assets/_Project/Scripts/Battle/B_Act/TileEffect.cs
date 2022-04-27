using System;
using System.Collections.Generic;

public class TileEffect
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<ActorEffectID> Effects { get; set; }

    public Action
        <TileActor /*User*/, 
        B_Tile /*Target*/,
        int /*Strength*/>
        InvokeEffect { get; set; }

    public void ApplyActorEffects(TileActor User, B_Tile Target, int Strength) {
        foreach (var effect in Effects) {
            foreach (var occupant in Target.GetOccupants()) {
                ActorEffectDB.ActorEffects[effect].InvokeEffect(occupant, Target.Location - User.Location, Strength);
            }
        }
    }
}
