using UnityEngine;
using UnityEngine.Events;
using CMF;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public class ActorFacing : MonoBehaviour
    {
        public UnityAction<Vector3> FaceDirectionUpdated;

        private Actor actor;
        public bool FaceMove { get; private set; } = true;
        public Vector3 FaceDirection { get; private set; } = Vector3.zero;

        public AnimationControl animControl;
        public TurnTowardControllerVelocity ttcv;
        public TurnTowardDirection ttd;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actor.SetFacingEvent += ActorFacingHandler;
        }

        private void ActorFacingHandler(Vector3 value)
        {
            FaceDirection = value;
            if (value == Vector3.zero)
            {
                FaceMove = true;
                animControl.useStrafeAnimations = false;
                ttcv.enabled = true;
                ttd.enabled = false;
            }
            else
            {
                FaceMove = false;
                animControl.useStrafeAnimations = true;
                ttcv.enabled = false;
                ttd.enabled = true;
                ttd.direction = FaceDirection;
            }
            Debug.Log("faceDirection " + FaceDirection);
            FaceDirectionUpdated?.Invoke(FaceDirection);
        }
    }
}