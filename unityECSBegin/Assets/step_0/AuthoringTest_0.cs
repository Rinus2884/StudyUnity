using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//entity�� �ٷ������
using Unity.Entities;

//component�� ������.(ecs������ component)
//<--IComponentData��� �������̽��� ��ӹ޾� �����.
//<--����ü�� �����

struct Test_0 : IComponentData
{

}


//entity�� �ϳ� ����� ����ϴ� ������ �Ѵ�.
public class AuthoringTest_0 : UnityEngine.MonoBehaviour
{
    //embedded class

    class BakerTeset_0 : Baker<AuthoringTest_0>
    {
        public override void Bake(AuthoringTest_0 authoring)
        {
            //������Ʈ �߰�
            AddComponent<Test_0>();
        }
    }


}
