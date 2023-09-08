using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

struct RyuActor : IComponentData
{
    public Entity PFBullet;
}


public class AuthoringActor : MonoBehaviour
{
    public UnityEngine.GameObject PFBullet = null;
    class BakerActor : Baker<AuthoringActor>
    {
        public override void Bake(AuthoringActor authoring)
        {
            AddComponent<RyuActor>(
                new RyuActor
                {
                    PFBullet = GetEntity(authoring.PFBullet)
                }
                );

        }
    }

}
