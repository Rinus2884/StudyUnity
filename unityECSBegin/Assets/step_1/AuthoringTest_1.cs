using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

struct SpawnerCube : IComponentData
{
    public Entity PFCube;   //ecs���ؿ��� �ٷ�� ���ӿ�����Ʈ(������)

}

public class AuthoringTest_1 : UnityEngine.MonoBehaviour
{
    public UnityEngine.GameObject PFcube = null;
    //������ unity ���ӿ�����Ʈ ���ؿ��� �ٷ�� ������ ����

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
