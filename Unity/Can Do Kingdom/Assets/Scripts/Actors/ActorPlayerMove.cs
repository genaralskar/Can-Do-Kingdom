using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(ActorFacing))]
    [RequireComponent(typeof(ActorMove))]
    public class ActorPlayerMove : ActorInputs
    {
        private Actor actor;
        private ActorFacing facing;
        private ActorMove move;

        private Vector2 moveDirection;
        private Vector2 faceDirection;
        public float speed = 5f;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            //facing = GetComponent<ActorFacing>();
            //move = GetComponent<ActorMove>();
        }

        // Update is called once per frame
        private void Update()
        {
            //if (!actor.playerControlling) return;
            //GetInputs();
            //move.SetMoveDirection(moveDirection);
            //move.SetMoveSpeed(speed);
        }

        private Vector3 GetInputs()
        {
            moveDirection.x = Input.GetAxis("Horizontal");
            moveDirection.y = Input.GetAxis("Vertical");
            if (facing.FaceMove)
            {
                faceDirection = moveDirection;
            }
            else
            {
                faceDirection = facing.FaceDirection;
            }

            return moveDirection;
        }

        public override Vector3 GetVectorInput()
        {
            throw new System.NotImplementedException();
        }

        public override bool GetJumpInput()
        {
            throw new System.NotImplementedException();
        }
    }
}