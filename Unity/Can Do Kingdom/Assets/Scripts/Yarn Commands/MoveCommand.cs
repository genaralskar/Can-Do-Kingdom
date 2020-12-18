using System;
using UnityEngine;
using Yarn.Unity;
using genaralskar.Actor;

public class MoveCommand : MonoBehaviour
{
    private enum MoveType { move, wait, instant }

    public DialogueRunner dialogueRunner;

    private void Awake()
    {
        dialogueRunner.AddCommandHandler("moveWait", MoveWait);
        dialogueRunner.AddCommandHandler("move", Move);
        dialogueRunner.AddCommandHandler("moveInstant", MoveInstant);
    }

    private void Move(string[] parameters)
    {
        MoveSetupNonBlocking(parameters, MoveType.move);
    }

    private void MoveInstant(string[] parameters)
    {
        MoveSetupNonBlocking(parameters, MoveType.instant);
    }

    private void MoveWait(string[] parameters, System.Action onComplete)
    {
        MoveSetupBlocking(parameters, onComplete, MoveType.wait);
    }

    private void MoveSetupBlocking(string[] parm, System.Action onComplete, MoveType type)
    {
        //find actor in scene with name parameters[0]
        Actor actor = SceneObjects.GetActor(parm[0]);

        //find location in scene with name parameters[1]
        Actor location = SceneObjects.GetActor(parm[1]);

        if (actor == null)
        {
            Debug.LogWarning($"No actor with name {parm[0]} found. Continuing dialogue");
            onComplete?.Invoke();
            return;
        }
        if (location == null)
        {
            Debug.LogWarning($"No actor with name {parm[1]} found. Destination not found, continuing dialogue");
            onComplete?.Invoke();
            return;
        }

        if (type == MoveType.wait)
        {
            actor.MoveActorBlocking(location.transform.position, onComplete);
        }
    }

    private void MoveSetupNonBlocking(string[] parms, MoveType type)
    {
        //find actor in scene with name parameters[0]
        Actor actor = SceneObjects.GetActor(parms[0]);

        //find location in scene with name parameters[1]
        Actor location = SceneObjects.GetActor(parms[1]);

        if (actor == null)
        {
            Debug.LogWarning($"No actor with name {parms[0]} found. Continuing dialogue");
            return;
        }

        if (location == null)
        {
            Debug.LogWarning($"No location with name {parms[1]} found. Continuing dialogue");
            return;
        }

        if (type == MoveType.move)
        {
            //Debug.Log("move to " + location.Position);
            actor.MoveActor(location.transform.position);
        }

        if (type == MoveType.instant)
        {
            actor.SetActorPosition(location.transform.position);
        }
    }
}
