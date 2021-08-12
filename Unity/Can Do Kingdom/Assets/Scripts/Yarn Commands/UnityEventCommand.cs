using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class UnityEventCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public UnityEvent[] events;

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler("unityEvent", UEvent);
    }

    private void UEvent(string[] parameters)
    {
        if (parameters == null)
        {
            return;
        }

        if(int.TryParse(parameters[0], out int i))
        {
            events[i].Invoke();
        }

    }
}
