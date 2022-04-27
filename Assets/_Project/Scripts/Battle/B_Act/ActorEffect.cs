using System;

public class ActorEffect
{
    public string Name { get; set; }
    public string Description { get; set; }

    public void InvokeEffect(TileActor target, CubeCoordinate direction, int strength) {
        var param = new ActorEffectParam(target, direction, strength);
        m_InvokeEffect(param);
    }
    public Action<ActorEffectParam> m_InvokeEffect { private get; set; }
}

public class ActorEffectParam
{
    public TileActor Target { get; }
    public CubeCoordinate Direction { get; }
    public int Strength { get; }
    public ActorEffectParam(TileActor target, CubeCoordinate direction, int strength) {
        Target = target;
        Direction = direction;
        Strength = strength;
    }
}