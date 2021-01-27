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

    public void OnInteract(genaralskar.Actor.Actor actor)
    {
        OnInteractEvent?.Invoke();
    }

    public void OnLeaveInteract(genaralskar.Actor.Actor actor)
    {
        OnInteractLeave.Invoke();
    }

    public void OnEnterInteract(genaralskar.Actor.Actor actor)
    {
        OnInteractEnter.Invoke();
    }
}
