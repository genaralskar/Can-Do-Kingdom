using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteractEvent;
    public UnityEvent OnInteractEnter;
    public UnityEvent OnInteractLeave;

    public string interactText;
    public string InteractText { get => interactText; }

    public void OnInteract()
    {
        OnInteractEvent?.Invoke();
    }

    public void OnLeaveInteract()
    {
        OnInteractLeave.Invoke();
    }

    public void OnEnterInteract()
    {
        OnInteractEnter.Invoke();
    }
}
