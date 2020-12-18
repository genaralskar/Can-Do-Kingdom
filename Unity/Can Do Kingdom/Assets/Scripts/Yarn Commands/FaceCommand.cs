using UnityEngine;
using Yarn.Unity;
using genaralskar.Actor;

public class FaceCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    [SerializeField]

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler("face", Face);
    }

    private void Face(string[] parameters)
    {
        if (parameters == null) return;
        //Debug.Log("facing" + parameters[0] + parameters[1] + parameters[2]);
        

        int actorNameIndex = 0;

        Vector3 faceDirection = Vector3.zero;
        if (parameters.Length == 3)
        {
            faceDirection.x = float.Parse(parameters[1]);
            faceDirection.z = float.Parse(parameters[2]);
        }

        /**
        Vector2 faceDirection = Vector2.zero;
        if (parameters[0] == "up")
        {
            faceDirection = Vector2.up;
            Debug.Log("facing up");
        }
        else if (parameters[0] == "left")
        {
            faceDirection = Vector2.left;
            Debug.Log("facing left");
        }
        else if (parameters[0] == "down")
        {
            faceDirection = Vector2.down;
            Debug.Log("facing down");
        }
        else if (parameters[0] == "right")
        {
            faceDirection = Vector2.right;
            Debug.Log("facing right");
        }
        else
        {
            Debug.Log("movment facing");
            actorNameIndex = 0;
        }
        **/

        //Debug.Log("setting facing to " + faceDirection);
        Actor a = SceneObjects.GetActor(parameters[actorNameIndex]);
        if (a != null)
            a.SetFacingEvent?.Invoke(faceDirection);
    }
}