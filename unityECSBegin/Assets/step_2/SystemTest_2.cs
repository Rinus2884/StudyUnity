using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;

using Unity.Collections;    //기존의 collections이 아니라 ecs에 있는 것
using Unity.Transforms;
using Unity.Mathematics;

/*
    System의 개념: 기능(로직)을 담는 클래스 (구조체)다    

    System ~클래스를 만드는 두가지 방식

    ISystem: 좀더 raw한 방식

        Unmanaged 방식
        MultiThread로 동작한다.(공유된 데이터의 관리가 핵심이다.)
        
        <-- struct로 작성해야 한다.
            (보다 raw한 원시적인 형태로 다루므로 구조체(값타입)로 만든다.
        <-- partial예약어를 적용해야 한다.
            (그렇다는 것은 ecs시스템 안에서 우리가 만든 System기능의 클래스(구조체)의 일정 부분을 담당하고 있는
            구조가 존재하한다고 추정가능하다.)



        Interface: 모양만 제공하는 클래스(형태를 강제한다)
 
    SystemBase: 좀더 편리한 방식


 */

[BurstCompile]
partial struct SystemTest_2 : ISystem
{
    bool mISBe;

    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        //SpawnerCube 가 로드되어야만 OnUpdate 가 구동될 수 있도록 제약한다 
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

            //등록해둔 컴포넌트를 얻는다.
            var tSpawnerCube = SystemAPI.GetSingleton<SpawnerCube_2>();

            //엔티티 게임오브젝트를 동작(시뮬레이션)시키는데 필요한 명령문 버퍼 관리자의 제어권을 얻는다.
            var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

            //명령문 버퍼를 만든다.
            EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

            //엔터티 게임오브젝트를 프리팹을 복제하여 하나 만든다.
            //Entity tCube = tECB.Instantiate(tSpawnerCube.PFCube);




            //5개의 entitty
            NativeArray<Entity> tCubes = CollectionHelper.CreateNativeArray<Entity>(5, Allocator.Temp);
            
            tECB.Instantiate(tSpawnerCube.PFCube, tCubes);
            //<--자료구조에 복제 생성된 엔티티들을 채워준다. 

            mISBe = true;
           
        }


        //멀티스레드 동작에서 공유된 데이터들의 안정성을 보장하기 위한 기능들이 추상화 되어 만들어져 있따.
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
            //회전코드
            //y축으로 회전
            transform.ValueRW = transform.ValueRO.RotateY(2.0f * deltaTime);
        }
        //update 중지
        //tState.Enabled = false;
    }
}
