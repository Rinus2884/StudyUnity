using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;

using Unity.Collections;    //������ collections�� �ƴ϶� ecs�� �ִ� ��

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
partial struct SystemTest_1 : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        //SpawnerCube �� �ε�Ǿ�߸� OnUpdate �� ������ �� �ֵ��� �����Ѵ� 
        tState.RequireForUpdate<SpawnerCube>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {
        //ecs ���ؿ��� ��ƼƼ ���� ������Ʈ �ϳ��� ����

        //����ص� ������Ʈ�� ��´�.
        var tSpawnerCube= SystemAPI.GetSingleton<SpawnerCube>();

        //��ƼƼ ���ӿ�����Ʈ�� ����(�ùķ��̼�)��Ű�µ� �ʿ��� ��ɹ� ���� �������� ������� ��´�.
        var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

        //��ɹ� ���۸� �����.
        EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

        //����Ƽ ���ӿ�����Ʈ�� �������� �����Ͽ� �ϳ� �����.
        //Entity tCube = tECB.Instantiate(tSpawnerCube.PFCube);




        //5���� entitty
       NativeArray<Entity> tCubes = CollectionHelper.CreateNativeArray<Entity>(5, Allocator.Temp);
        tECB.Instantiate(tSpawnerCube.PFCube, tCubes);
        //<--�ڷᱸ���� 


        //update ����
        tState.Enabled = false;

    }
}
