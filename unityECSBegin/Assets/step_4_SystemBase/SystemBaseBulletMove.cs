using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

using Unity.Transforms;
using Unity.Mathematics;

partial class SystemBaseBulletMove : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();
    }

    protected override void OnDestroy()
    {
       
    }


    protected override void OnUpdate()
    {
        var tDeltaTime = SystemAPI.Time.DeltaTime;


        foreach (var (tBulletTransform, t, tBullet) in SystemAPI.Query<RefRW<LocalTransform>,
              LocalTransform, RefRW<RyuBaseBullet>>())
        {
            foreach (var (tActorTransform, tB) in SystemAPI.Query<RefRW<LocalTransform>,
                LocalTransform>().WithAny<RyuBaseActor>())
            {
                //발사되어
                if (false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }

            }
        }
        Vector3 tVelocity = Vector3.forward;
    

        tVelocity = tVelocity * 10f * tDeltaTime;

        Entities.WithAny<RyuBaseBullet>().ForEach(
            (Entity t, TransformAspect tAspect) =>
            {
                float3 tVel = (float3)tVelocity;

                tAspect.LocalPosition = tAspect.LocalPosition + tVel;
            }
            ).ScheduleParallel();
    }


}
