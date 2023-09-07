using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

struct SpawnerCube : IComponentData
{
    public Entity PFCube;   //ecs수준에서 다루는 게임오브젝트(프리펩)

}

public class AuthoringTest_1 : UnityEngine.MonoBehaviour
{
    public UnityEngine.GameObject PFcube = null;
    //기존의 unity 게임오브젝트 수준에서 다루는 프리팹 개념

    class BakerTest_1 : Baker<AuthoringTest_1>
    {
        public override void Bake(AuthoringTest_1 authoring)
        {
            AddComponent<SpawnerCube>
            (
             new SpawnerCube
             {
                 PFCube = GetEntity(authoring.PFcube)

             }
            ) ;
        }


    }


}
