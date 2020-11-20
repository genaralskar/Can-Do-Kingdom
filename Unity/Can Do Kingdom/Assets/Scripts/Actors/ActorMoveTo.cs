using System.Collections;
using UnityEngine;
using CMF;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(ActorCharacterInput))]
    public class ActorMoveTo : MonoBehaviour
    {
        private Actor actor;
        private bool isPlayer = false;
        private Vector3 direction = Vector3.zero;
        private ActorCharacterInput aci;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actor.MoveEvent += MoveActorHandler;
            aci = GetComponent<ActorCharacterInput>();
        }

        private void MoveActorHandler(Vector3 location)
        {
            Debug.Log("Move to " + location);
            StopAllCoroutines();
            isPlayer = actor.playerControlling;
            actor.playerControlling = false;
            StartCoroutine(MoveTo(location));
        }

        private IEnumerator MoveTo(Vector3 location)
        {
            Debug.Log("Starting move!");
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            while (Vector3.Distance(actor.transform.position, location) > .1f)
            {
                //Debug.Log("Distance: " + Vector3.Distance(actor.transform.position, location));
                //get direction
                direction = location - actor.transform.position;
                aci.SetMoveDirection(direction);
                //actorMove.SetMoveDirection(direction);
                yield return wait;
            }
            Debug.Log("Ending Move!");
            actor.transform.position = location;
            actor.MoveFinishEvent();
            direction = Vector3.zero;
            aci.SetMoveDirection(direction);
            //actorMove.SetMoveDirection(Vector3.zero);
            if (isPlayer)
                actor.playerControlling = true;
        }
    }
}