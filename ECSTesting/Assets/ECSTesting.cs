using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class ECSTesting : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    private void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(PositionComponent),
            typeof(Translation),
            typeof(Rotation),
            typeof(RotationComponent),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent)
        );
        NativeArray<Entity> entityArray = new NativeArray<Entity>(1000, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i  = 0; i < entityArray.Length; i ++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new PositionComponent { position = new Vector3(1f * i, 1f * i, 0.0f) });
            entityManager.SetComponentData(entity, new MoveSpeedComponent { velocity = UnityEngine.Random.onUnitSphere });
            entityManager.SetComponentData(entity, new Translation { Value = new Unity.Mathematics.float3(UnityEngine.Random.Range(-10f, 10f), 0f, UnityEngine.Random.Range(-10f, 10f)) });
            entityManager.SetComponentData(entity, new Rotation { Value = new quaternion() });
            entityManager.SetComponentData(entity, new RotationComponent { EulerRotation = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f)) });
            
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material,
            }); 
        }
        entityArray.Dispose();
    }

   
}
