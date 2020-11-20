using UnityEngine;
using CMF;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public class ActorCharacterInput : CharacterInput
    {
        public bool dialogControl = false;
        public ActorInputs input;
        private ActorInputs defaultInput;
        private Vector3 moveDirection;
        private bool jump;

        private void Awake()
        {
            if (!input)
            {
                input = GetComponent<ActorInputs>();
                if(!input)
                {
                    Debug.LogError("No ActorInputs found or assigned for " + this);
                }
            }

            defaultInput = input;
        }

        public override float GetHorizontalMovementInput()
        {
            return moveDirection.x;
            //return input.GetHorizontalInput();
        }

        public override float GetVerticalMovementInput()
        {
            return moveDirection.z;
            //return input.GetVerticalInput();
        }

        public override bool IsJumpKeyPressed()
        {
            return jump;
            //return input.GetJumpInput();
        }

        public void SetMoveDirection(Vector3 newDir)
        {
            moveDirection = newDir;
        }

        public void SetInput(ActorInputs newInput)
        {
            input = newInput; 
        }

        public void ResetInput()
        {
            input = defaultInput;
        }
    }
}
