using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnStartInteract();
    void OnInteract();
    void OnLeaveInteract();
}
