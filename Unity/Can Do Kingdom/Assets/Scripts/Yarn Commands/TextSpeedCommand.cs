using UnityEngine;
using Yarn.Unity;

public class TextSpeedCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private DialogueUI dui;
    private float speedDefault;

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();   
    }

    private void Start()
    {
        dui = dialogueRunner.dialogueUI.gameObject.GetComponent<DialogueUI>();
        dialogueRunner.AddCommandHandler("textSpeed", Speed);
        speedDefault = dui.textSpeed;
    }

    private void Speed(string[] parameters)
    {
        float speed = float.Parse(parameters[0]);
        if (speed <= 0)
        {
            dui.textSpeed = speedDefault;
        }
        else
        {
            dui.textSpeed = speed;
        }
    }
}
