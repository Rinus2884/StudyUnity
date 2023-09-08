using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Transforms;

[BurstCompile]
partial struct SystemBulletMove: ISystem
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



        ////탄환의 발사 시작위치를 (주인공 기체의 위치로)설정한다.
        //foreach(var(tBulletTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())

     
        foreach (var (tBulletTransform, t,tBullet) in SystemAPI.Query<RefRW<LocalTransform>,
               LocalTransform,RefRW<RyuBullet>>())
        {
            foreach(var(tActorTransform,tB) in SystemAPI.Query<RefRW<LocalTransform>,
                LocalTransform>().WithAny<RyuActor>())
            {
                //발사되어
                if(false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }
                
            }
        }
        


        float deltaTime = SystemAPI.Time.DeltaTime; //프레임당 시간구하기


       

        Vector3 tVelocity = Vector3.forward;
        tVelocity.Normalize();

        //초당 10미터
        tVelocity = tVelocity * 10f * deltaTime;

        //RyuActor컴포넌트가 부착되어 있는 엔티티들에 대해서
        //LocalTransform 컴포넌트에 대해 조회한다.
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
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
