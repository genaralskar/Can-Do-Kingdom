using UnityEngine;
using Yarn.Unity;

public abstract class BlockingCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    [SerializeField]
    protected string commandName;

    protected virtual void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler(commandName, Command);
    }

    protected abstract void Command(string[] parameters, System.Action onComplete);
}
