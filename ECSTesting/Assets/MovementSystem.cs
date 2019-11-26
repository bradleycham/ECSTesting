using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent, ref Rotation rotation, ref RotationComponent rotCom) =>
        {
            translation.Value.x += moveSpeedComponent.velocity.x * Time.deltaTime;
            translation.Value.y += moveSpeedComponent.velocity.y * Time.deltaTime;
            translation.Value.z += moveSpeedComponent.velocity.z * Time.deltaTime;

            rotation.Value = Quaternion.Euler(new Vector3(rotCom.EulerRotation.x * Time.time, rotCom.EulerRotation.y * Time.time, rotCom.EulerRotation.z * Time.time));

        });
    }
}
