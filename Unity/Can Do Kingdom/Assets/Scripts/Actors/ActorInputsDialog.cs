using UnityEngine;

namespace genaralskar.Actor
{
    public class ActorInputsDialog : ActorInputs
    {
        private Vector3 moveDirection;
        private bool jump = false;
        public override Vector3 GetVectorInput()
        {
            return moveDirection;
        }

        public override bool GetJumpInput()
        {
            return jump;
        }

        public void SetMoveDirection(Vector3 dir)
        {
            moveDirection = dir;
        }

        public void SetJump(bool newJump)
        {
            jump = newJump;
        }
    }
}
