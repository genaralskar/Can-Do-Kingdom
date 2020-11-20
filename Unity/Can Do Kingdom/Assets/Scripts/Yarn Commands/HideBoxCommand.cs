using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class HideBoxCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public UnityEvent OnHideBox;

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler("hideBox", HideBox);
    }

    private void HideBox(string[] parameters)
    {
        OnHideBox.Invoke();
    }
}
