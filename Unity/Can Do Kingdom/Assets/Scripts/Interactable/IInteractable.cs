using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string InteractText { get; }

    void OnEnterInteract();
    void OnInteract();
    void OnLeaveInteract();
}
