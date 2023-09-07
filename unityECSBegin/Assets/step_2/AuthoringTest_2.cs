using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Mathematics;

struct SpawnerCube_2 : IComponentData
{
    public Entity PFCube;   //ecs수준에서 다루는 게임오브젝트(프리펩)
    
}

    public class AuthoringTest_2 : UnityEngine.MonoBehaviour
{
    public UnityEngine.GameObject PFcube = null;
    //기존의 unity 게임오브젝트 수준에서 다루는 프리팹 개념

    class BakerTest_2 : Baker<AuthoringTest_2>
    {
        public override void Bake(AuthoringTest_2 authoring)
        {
            AddComponent<SpawnerCube_2>
            (
             new SpawnerCube_2
             {
                 PFCube = GetEntity(authoring.PFcube)

             }
            ) ;
        }


    }


}
