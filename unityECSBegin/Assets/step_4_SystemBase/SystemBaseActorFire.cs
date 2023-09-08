using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

using Unity.Transforms;
using Unity.Mathematics;

partial class SystemBaseActorFire : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }


    protected override void OnUpdate()
    {
        //藕券积己
        bool tIsFire = Input.GetKeyDown(KeyCode.Space);

        if(tIsFire)
        {
            //Isystem焊促 流包利烙
            var tActor = SystemAPI.GetSingleton<RyuBaseActor>();
            EntityManager.Instantiate(tActor.PFBullet);
        }
    }

}
