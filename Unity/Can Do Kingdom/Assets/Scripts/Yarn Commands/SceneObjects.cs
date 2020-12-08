using System.Collections.Generic;
using UnityEngine;
using genaralskar.Actor;
using Cinemachine;

public class SceneObjects : MonoBehaviour
{
    private static List<Actor> actors = new List<Actor>();
    private static List<Location> locations = new List<Location>();
    private static List<CinemachineVirtualCamera> vcams = new List<CinemachineVirtualCamera>();

    private void Awake()
    {
        //get list of all actors
        actors.AddRange(FindObjectsOfType<Actor>());
        //get list of all locations
        locations.AddRange(FindObjectsOfType<Location>());
        //get list of all virual cams
        vcams.AddRange(Resources.FindObjectsOfTypeAll<CinemachineVirtualCamera>());
    }

    public static Actor GetActor(string name)
    {
        //look for actor by actor name, then by gameobject name
        int i = actors.FindIndex(x => x.actorName == name);
        if (i < 0)
            i = actors.FindIndex(x => x.name == name);

        if(i < 0)
        {
            Debug.LogWarning($"No actor with name {name} found.");
            return null;
        }
        return actors[i];
    }

    public static Actor GetActorFromActorName(string name)
    {
        int i = actors.FindIndex(x => x.actorName != "" && x.actorName == name);
        if (i < 0)
        {
            Debug.LogWarning($"No actor with actorName {name} found.");
            return null;
        }
        return actors[i];
    }

    public static Vector2 GetActorPosition(string name, out bool success)
    {
        int i = actors.FindIndex(x => x.actorName != "" && x.actorName == name);
        if (i < 0)
        {
            Debug.LogWarning($"No actor with name {name} found.");
            success = false;
            return Vector2.zero;
        }
        success = true;
        return (Vector2)actors[i].transform.position;
    }

    public static Location GetLocation(string name)
    {
        int i = locations.FindIndex(x => x.name == name);
        if (i < 0)
        {
            Debug.LogWarning($"No location with name {name} found.");
            return null;
        }
        return locations[i];
    }

    public static CinemachineVirtualCamera GetVCam(string name)
    {
        int i = vcams.FindIndex(x => x.name == name);
        if (i < 0)
        {
            Debug.LogWarning($"No Virtual Camera with name {name} found.");
            return null;
        }
        return vcams[i];
    }
}
