using UnityEngine;
using UnityEngine.Events;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public class ActorMove : MonoBehaviour
    {
        public UnityAction<Vector2> MoveDirectionUpdated;
        public UnityAction<Vector2> FaceDirectionUpdated;
        public UnityAction<float> SpeedUpdated;

        private Actor actor;
        private ActorMoveAnimator moveAnimator;
        private ActorFacing actorFacing;

        [SerializeField]
        private float moveSpeed = 5;
        private float defaultSpeed = 5f;

        public Vector2 MoveDirection { get; private set; } = Vector2.zero;
        private Vector2 previousPosition = Vector2.zero;
        public Vector2 Velocity => (previousPosition - (Vector2)transform.position) / Time.deltaTime;
        public float CurrentSpeed => Velocity.magnitude;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actorFacing = GetComponent<ActorFacing>();
            moveAnimator = GetComponent<ActorMoveAnimator>();
            if (moveAnimator)
            {
                SpeedUpdated += moveAnimator.SetActorSpeed;
                if (actorFacing)
                {
                    actorFacing.FaceDirectionUpdated += moveAnimator.SetActorFaceDirection;
                }
            }

            defaultSpeed = moveSpeed;
        }

        private void Update()
        {
            previousPosition = transform.position;
            transform.Translate(MoveDirection.normalized * moveSpeed * Time.deltaTime);
            SpeedUpdated?.Invoke(CurrentSpeed);

            if (actorFacing && actorFacing.FaceMove && CurrentSpeed > .01f)
            {
                moveAnimator.SetActorFaceDirection(MoveDirection);
            }
        }

        public void SetMoveDirection(Vector2 direction)
        {
            MoveDirection = direction;
            MoveDirectionUpdated?.Invoke(MoveDirection.normalized);
        }

        public void SetMoveSpeed(float speed)
        {
            if (speed <= 0)
            {
                moveSpeed = defaultSpeed;
            }
            else
            {
                moveSpeed = speed;
            }
        }
    }
}