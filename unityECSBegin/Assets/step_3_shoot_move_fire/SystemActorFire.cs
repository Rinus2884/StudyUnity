using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Transforms;

[BurstCompile]
partial struct SystemActorFire: ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        tState.RequireForUpdate<RyuActor>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {
        //입력에 의한 zx 평면에서의 위치값 갱신 코드
        bool tIsFire = Input.GetKeyDown(KeyCode.Space);

        if (tIsFire)
        {
            var tActor = SystemAPI.GetSingleton<RyuActor>();

            var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

           
            //EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);
            var tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

            Entity tBullet = tECB.Instantiate(tActor.PFBullet);
        }
    }

}
