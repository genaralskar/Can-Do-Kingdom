using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class AutoContinueCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public DialogueUI dui;
    public UnityEvent OnLineFinishDisplaying;

    private bool autoGo = false;
    private float delay = 0;

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dui == null)
            dui = FindObjectOfType<DialogueUI>();

        dialogueRunner.AddCommandHandler("autoContinue", AutoGo);
    }

    private void AutoGo(string[] parameters)
    {
        autoGo = true;
        if (parameters != null)
            delay = float.Parse(parameters[0]);

        delay = delay < 0 ? 0 : delay;
    }

    public void LineFinish()
    {
        if(autoGo)
        {
            StopAllCoroutines();
            StartCoroutine(LineWait());
        }
        else
        {
            OnLineFinishDisplaying.Invoke();
        }
    }

    private IEnumerator LineWait()
    {
        yield return new WaitForSeconds(delay);
        autoGo = false;
        dui.MarkLineComplete();
    }
}
