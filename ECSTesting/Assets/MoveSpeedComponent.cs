using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct MoveSpeedComponent : IComponentData
{
    public Vector3 velocity;
}
