using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;

using Unity.Collections;    //������ collections�� �ƴ϶� ecs�� �ִ� ��
using Unity.Transforms;
using Unity.Mathematics;

/*
    System�� ����: ���(����)�� ��� Ŭ���� (����ü)��    

    System ~Ŭ������ ����� �ΰ��� ���

    ISystem: ���� raw�� ���

        Unmanaged ���
        MultiThread�� �����Ѵ�.(������ �������� ������ �ٽ��̴�.)
        
        <-- struct�� �ۼ��ؾ� �Ѵ�.
            (���� raw�� �������� ���·� �ٷ�Ƿ� ����ü(��Ÿ��)�� �����.
        <-- partial���� �����ؾ� �Ѵ�.
            (�׷��ٴ� ���� ecs�ý��� �ȿ��� �츮�� ���� System����� Ŭ����(����ü)�� ���� �κ��� ����ϰ� �ִ�
            ������ �������Ѵٰ� ���������ϴ�.)



        Interface: ��縸 �����ϴ� Ŭ����(���¸� �����Ѵ�)
 
    SystemBase: ���� ���� ���


 */

[BurstCompile]
partial struct SystemTest_2 : ISystem
{
    bool mISBe;

    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        //SpawnerCube �� �ε�Ǿ�߸� OnUpdate �� ������ �� �ֵ��� �����Ѵ� 
        tState.RequireForUpdate<SpawnerCube_2>();

        mISBe = false;
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {

        if (!mISBe)
        {

            //����ص� ������Ʈ�� ��´�.
            var tSpawnerCube = SystemAPI.GetSingleton<SpawnerCube_2>();

            //��ƼƼ ���ӿ�����Ʈ�� ����(�ùķ��̼�)��Ű�µ� �ʿ��� ��ɹ� ���� �������� ������� ��´�.
            var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

            //��ɹ� ���۸� �����.
            EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

            //����Ƽ ���ӿ�����Ʈ�� �������� �����Ͽ� �ϳ� �����.
            //Entity tCube = tECB.Instantiate(tSpawnerCube.PFCube);




            //5���� entitty
            NativeArray<Entity> tCubes = CollectionHelper.CreateNativeArray<Entity>(5, Allocator.Temp);
            
            tECB.Instantiate(tSpawnerCube.PFCube, tCubes);
            //<--�ڷᱸ���� ���� ������ ��ƼƼ���� ä���ش�. 

            mISBe = true;
           
        }


        //��Ƽ������ ���ۿ��� ������ �����͵��� �������� �����ϱ� ���� ��ɵ��� �߻�ȭ �Ǿ� ������� �ֵ�.
        //REFRW: referenece read write
        //RefRO: referenece read only
        float3 tPos = float3.zero;
        foreach (var (transform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        {
            var tAngle = (0.5f + noise.cnoise(tPos / 10.0f)) * 4f * math.PI;
            math.sincos(tAngle, out tPos.x, out tPos.z);


            transform.ValueRW._Position = tPos * 5f;
        }

        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach(var (transform,t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        {
            //ȸ���ڵ�
            //y������ ȸ��
            transform.ValueRW = transform.ValueRO.RotateY(2.0f * deltaTime);
        }
        //update ����
        //tState.Enabled = false;
    }
}
