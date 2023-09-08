using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

struct RyuBaseActor : IComponentData
{
    public Entity PFBullet;
}


public class AuthoringBaseActor : MonoBehaviour
{
    public UnityEngine.GameObject PFBullet = null;
    class BakerBaseActor : Baker<AuthoringBaseActor>
    {
        public override void Bake(AuthoringBaseActor authoring)
        {
            AddComponent<RyuBaseActor>(
                new RyuBaseActor
                {
                    PFBullet = GetEntity(authoring.PFBullet)
                }
                );

        }
    }

}
