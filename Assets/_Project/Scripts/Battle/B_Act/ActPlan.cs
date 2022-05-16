using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlan
{
    protected TileActor User;

    public Queue<Vector3> DirectionLine { protected get; set; }
    public Queue<CubeCoordinate> Path { protected get; set; }

    protected PersonalAct Act;

    protected int strength;

    protected bool PlanCompleted = false;
    protected bool PlanInterrupted = false;

    public int tickDuration;
}