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



        ////źȯ�� �߻� ������ġ�� (���ΰ� ��ü�� ��ġ��)�����Ѵ�.
        //foreach(var(tBulletTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())

     
        foreach (var (tBulletTransform, t,tBullet) in SystemAPI.Query<RefRW<LocalTransform>,
               LocalTransform,RefRW<RyuBullet>>())
        {
            foreach(var(tActorTransform,tB) in SystemAPI.Query<RefRW<LocalTransform>,
                LocalTransform>().WithAny<RyuActor>())
            {
                //�߻�Ǿ�
                if(false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }
                
            }
        }
        


        float deltaTime = SystemAPI.Time.DeltaTime; //�����Ӵ� �ð����ϱ�


       

        Vector3 tVelocity = Vector3.forward;
        tVelocity.Normalize();

        //�ʴ� 10����
        tVelocity = tVelocity * 10f * deltaTime;

        //RyuActor������Ʈ�� �����Ǿ� �ִ� ��ƼƼ�鿡 ���ؼ�
        //LocalTransform ������Ʈ�� ���� ��ȸ�Ѵ�.
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
        {

            //�ش� ��ġ�� ����
            tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        }


        //foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        //{

        //    //�ش� ��ġ�� ����
        //    tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        //}
    }

}
