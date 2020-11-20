using System.Collections;
using UnityEngine;
using CMF;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(ActorCharacterInput))]
    public class ActorMoveTo : ActorInputs
    {
        private Actor actor;
        private Vector3 direction = Vector3.zero;
        private Vector3 destination;
        private bool isMoving = false;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actor.MoveEvent += MoveActorHandler;
        }

        private void MoveActorHandler(Vector3 location)
        {
            //Debug.Log("Move to " + location);
            destination = location;
            isMoving = true;
        }

        public override Vector3 GetVectorInput()
        {
            if(!isMoving) return Vector3.zero;
            //do stuff when we get to the destination
            if (Vector3.Distance(actor.transform.position, destination) < .1f)
            {
                actor.transform.position = destination;
                actor.MoveFinishEvent();
                isMoving = false;
                return Vector3.zero;
            }

            direction = destination - actor.transform.position;
            return direction;
        }

        public override bool GetJumpInput()
        {
            return false;
        }
    }
}