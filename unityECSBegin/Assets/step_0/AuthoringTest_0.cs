using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//entity를 다루기위해
using Unity.Entities;

//component를 만들자.(ecs에서의 component)
//<--IComponentData라는 인터페이스를 상속받아 만든다.
//<--구조체로 만든다

struct Test_0 : IComponentData
{

}


//entity를 하나 만들어 등록하는 역할을 한다.
public class AuthoringTest_0 : UnityEngine.MonoBehaviour
{
    //embedded class

    class BakerTeset_0 : Baker<AuthoringTest_0>
    {
        public override void Bake(AuthoringTest_0 authoring)
        {
            //컴포넌트 추가
            AddComponent<Test_0>();
        }
    }


}
