using UnityEngine;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(ActorAnimator))]
    public class ActorMoveAnimator : MonoBehaviour
    {
        private Actor actor;
        private ActorAnimator actorAnimator;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actorAnimator = GetComponent<ActorAnimator>();
        }

        public void SetActorSpeed(float speed)
        {
            actorAnimator.UpdateAnimatorFloat("speed", speed);
        }

        public void SetActorFaceDirection(Vector3 direction)
        {
            //Debug.Log("Animator faceDirection " + direction);
            actorAnimator.UpdateAnimatorFloat("faceX", direction.x);
            actorAnimator.UpdateAnimatorFloat("faceY", direction.y);
        }
    }
}