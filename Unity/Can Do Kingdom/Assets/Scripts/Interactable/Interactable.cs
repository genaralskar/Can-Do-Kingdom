using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteractEvent;
    public UnityEvent OnInteractStart;
    public UnityEvent OnInteractLeave;
    public void OnInteract()
    {
        OnInteractEvent?.Invoke();
    }

    public void OnLeaveInteract()
    {
        
    }

    public void OnStartInteract()
    {

    }
}
