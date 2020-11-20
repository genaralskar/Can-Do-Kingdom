using UnityEngine;
using Yarn.Unity;
namespace genaralskar.Actor
{
	[RequireComponent(typeof(ActorCharacterInput))]
	public class ActorPlayerInputs : ActorInputs
	{
		public string horizontalInputAxis = "Horizontal";
		public string verticalInputAxis = "Vertical";
		public string jumpInput = "Jump";

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;

		private ActorCharacterInput aci;

        private void Awake()
        {
			aci = GetComponent<ActorCharacterInput>();

			DialogueUI ui = FindObjectOfType<DialogueUI>();
			if (ui == null)
			{
				Debug.LogWarning("No DialogueUI Object is find the scene! Add one unless you meant " +
					"to not have one.");
			}
			else
            {
				ui.onDialogueStart.AddListener(DialogueStartHandler);
				ui.onDialogueEnd.AddListener(DialogueEndHandler);
			}
        }

        public override Vector3 GetVectorInput()
		{
			Vector3 input = Vector3.zero;
			if (useRawInput)
			{
				input.x = Input.GetAxisRaw(horizontalInputAxis);
				input.z = Input.GetAxisRaw(verticalInputAxis);
			}
			else
			{
				input.x = Input.GetAxis(horizontalInputAxis);
				input.z = Input.GetAxis(verticalInputAxis);
			}
			return input;
		}

		public override bool GetJumpInput()
		{
			//Debug.Log(Input.GetButton(jumpInput));
			return Input.GetButton(jumpInput);
		}

		private void DialogueStartHandler()
        {
			aci.SetDialogInput();
        }

		private void DialogueEndHandler()
        {
			aci.ResetInput();
        }
	}
}
