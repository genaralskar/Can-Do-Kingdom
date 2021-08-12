using genaralskar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string InteractText { get; }

    void OnEnterInteract(genaralskar.Actor.Actor actor);
    void OnInteract(genaralskar.Actor.Actor actor);
    void OnLeaveInteract(genaralskar.Actor.Actor actor);
}
