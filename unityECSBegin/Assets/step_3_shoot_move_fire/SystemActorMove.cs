using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Transforms;

[BurstCompile]
partial struct SystemActorMove: ISystem
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
        float deltaTime = SystemAPI.Time.DeltaTime; //프레임당 시간구하기


        //입력에 의한 zx 평면에서의 위치값 갱신 코드
        float tForward = Input.GetAxis("Vertical");
        float tRight = Input.GetAxis("Horizontal");

        Vector3 tVelocity = Vector3.forward * tForward + Vector3.right * tRight;
        tVelocity.Normalize();

        //초당 10미터
        tVelocity = tVelocity * 10f * deltaTime;

        //RyuActor컴포넌트가 부착되어 있는 엔티티들에 대해서
        //LocalTransform 컴포넌트에 대해 조회한다.
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuActor>())
        {

            //해당 위치로 지정
            tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        }


        //foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        //{

        //    //해당 위치로 지정
        //    tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        //}
    }

}
