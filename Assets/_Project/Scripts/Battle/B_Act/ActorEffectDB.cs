using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEffectDB : MonoBehaviour
{
    public static Dictionary<ActorEffectID, ActorEffect> ActorEffects = new Dictionary<ActorEffectID, ActorEffect>()
    {
        {
            ActorEffectID.test,
            new ActorEffect()
            {
                Name = "Test",
                Description = "This is the test ActorEffect description.",

                m_InvokeEffect = (ActorEffectParam e) =>
                {
                    Debug.Log($"This applied the Test effect on {e.Target.Name}, in the {e.Direction} direction, with a strength of {e.Strength}.");
                }
            }
        },
        {
            ActorEffectID.MOVE,
            new ActorEffect()
            {
                Name = "Move",
                Description = "Moves the target in the direction, a number of steps equal to strength.",

                m_InvokeEffect = (ActorEffectParam e) =>
                {
                    e.Target.MoveTo(e.Target.WorldFromRelative(e.Direction));
                }
            }
        },
        {
            ActorEffectID.DMG,
            new ActorEffect()
            {
                Name = "Damage",
                Description = "Reduce Health",

                m_InvokeEffect = (ActorEffectParam e) =>
                {
                    if (e.Target is IDamageable damageable)
                        damageable.TakeDamage(e.Strength);
                }
            }
        }
    };
}

public enum ActorEffectID
{
    test,

    MOVE,
    DMG,
    HEAT
}