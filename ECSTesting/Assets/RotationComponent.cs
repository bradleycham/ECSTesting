using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct RotationComponent : IComponentData
{
    public Vector3 EulerRotation;
}