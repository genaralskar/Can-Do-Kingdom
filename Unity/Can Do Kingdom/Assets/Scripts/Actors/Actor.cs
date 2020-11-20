using UnityEngine;
using UnityEngine.Events;

namespace genaralskar.Actor
{
    public class Actor : MonoBehaviour
    {
        public UnityAction<Vector3> MoveEvent;
        public UnityAction<Vector3> SetPositionEvent;
        public UnityAction MoveFinishEvent;
        public UnityAction<Vector3> SetFacingEvent;
        public UnityAction<float> SetMoveSpeedEvent;
        public UnityAction<string, bool> SetAnimatorBool;
        public UnityAction<string, float> SetAnimatorFloat;
        public UnityAction<string> SetAnimatorTrigger;
        public UnityAction<int> DamageActor;

        private System.Action blockingHolder;

        [Tooltip("This is the name that is used to match the actor to dialog." +
            "This should be the same as how the name appears in a dialogue")]
        public string actorName;
        public bool playerControlling = false;

        private Vector3 startPos;
        public Vector3 StartPos => startPos;

        private void Awake()
        {
            startPos = transform.position;
            MoveFinishEvent += ActorFinishMoveHandler;
        }

        public void MoveActor(Vector3 location)
        {
            Debug.Log("Actor: move to " + location);
            MoveEvent?.Invoke(location);
        }

        public void MoveActorBlocking(Vector3 location, System.Action onComplete)
        {
            blockingHolder = onComplete;
            MoveActor(location);
        }

        public void SetActorPosition(Vector3 location)
        {
            SetPositionEvent?.Invoke(location);
        }

        private void ActorFinishMoveHandler()
        {
            blockingHolder?.Invoke();
            blockingHolder = null;
        }
    }
}