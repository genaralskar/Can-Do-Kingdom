using UnityEngine;
using CMF;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public class ActorCharacterInput : CharacterInput
    {
        public ActorInputs input;
        private ActorInputs defaultInput;
        public ActorInputs defaultDialogInput;


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

        public void SetDialogInput()
        {
            input = defaultDialogInput;
        }

        public override float GetHorizontalMovementInput()
        {
            //return moveDirection.x;
            return input.GetVectorInput().x;
        }

        public override float GetVerticalMovementInput()
        {
            //return moveDirection.z;
            return input.GetVectorInput().z;
        }

        public override bool IsJumpKeyPressed()
        {
            //return jump;
            return input.GetJumpInput();
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
