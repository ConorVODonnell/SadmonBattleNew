using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffectDB
{
    public static Dictionary<TileEffectID, TileEffect> TileEffects = new Dictionary<TileEffectID, TileEffect>()
    {
        {
            TileEffectID.test,
            new TileEffect()
            {
                Name = "Test",
                Description = "This is the Test TileEffect description",

                InvokeEffect = (TileActor User, B_Tile Target, int Strength) =>
                {
                    Debug.Log($"The test TileEffect performed by {User.Name}");
                }
            }
        },
        {
            TileEffectID.DMG,
            new TileEffect()
            {
                Name = "Damage",
                Description = "Applies direct damage to IDamageable objects",

                Effects = new List<ActorEffectID>()
                {
                    ActorEffectID.DMG
                },

                InvokeEffect = (TileActor User, B_Tile Target, int Strength) =>
                {
                    if (Target.HasSademon(out SadeTA sadeTA)) {
                        foreach (var occupant in Target.GetOccupants())
                        ActorEffectDB.ActorEffects[ActorEffectID.DMG].InvokeEffect(sadeTA, Target.Location - User.Location, Strength);
                    }
                    else {
                        Debug.Log($"There was no Sademon on {Target.Location}");
                    }
                }
            }
        },
        {
            TileEffectID.BRN,
            new TileEffect()
            {
                Name = "Burn",
                Description = "Increases heat, applies damage",

                Effects= new List<ActorEffectID>()
                {
                    ActorEffectID.DMG,
                    ActorEffectID.HEAT
                }
            }
        }
    };
}

public enum TileEffectID
{
    test,

    DMG,
    BRN,
    SOAK,
    GROW
}