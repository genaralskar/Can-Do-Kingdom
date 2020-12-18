using UnityEngine;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public abstract class ActorInputs: MonoBehaviour
    {
        public abstract Vector3 GetVectorInput();
        public abstract bool GetJumpInput();
    }
}
