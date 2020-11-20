using UnityEngine;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public abstract class ActorInputs: MonoBehaviour
    {
        public abstract float GetHorizontalInput();
        public abstract float GetVerticalInput();
        public abstract bool GetJumpInput();
    }
}
