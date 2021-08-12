using UnityEngine;
using Yarn.Unity;
using Cinemachine;
using genaralskar.Actor;

public class CameraCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public CinemachineVirtualCamera trackCam;
    private bool tracking = false;

    private CinemachineVirtualCamera activeCam;

    private void Awake()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler("cam", Cam);
    }

    private void Cam(string[] parameters)
    {
        //<<cam>> will disable camName
        if (parameters == null)
        {
            ResetCam();
            return;
        }

        if(parameters[0] == "track")
        {
            StartTrackCam();
            return;
        }
        StopTrackCam();
        //get cam
        CinemachineVirtualCamera newCam = SceneObjects.GetVCam(parameters[0]);
        //Debug.Log($"{newCam} selected, param0 {parameters[0]}");
        ActivateCamera(newCam);
            
    }

    //properly sets/enables a new active camera while disabling the old active camera
    private void ActivateCamera(CinemachineVirtualCamera newCam)
    {
        if (activeCam != null)
        {
            activeCam.gameObject.SetActive(false);
        }

        activeCam = newCam;

        //enable/disable cam
        if (activeCam)
        {
            activeCam.gameObject.SetActive(true);
            //Debug.Log("Enabling Cam!");
        }
    }

    public void ResetCam()
    {
        StopTrackCam();
        if (activeCam == null) return;
        activeCam.gameObject.SetActive(false);
        activeCam = null;
    }

    private void StartTrackCam()
    {
        if (tracking) return;
        DialogSplitter.DialogNameSplit += TrackCam;
        tracking = true;
        Debug.Log("Tracking started");
    }

    private void StopTrackCam()
    {
        if (!tracking) return;
        DialogSplitter.DialogNameSplit -= TrackCam;
        tracking = false;
    }

    private void TrackCam(string actorName)
    {
        Debug.Log($"tracking {actorName}");

        Actor actor = SceneObjects.GetActor(actorName);

        if (actorName == "" || actorName == "Player" || actor == null)
        {
            if (activeCam == null) return;
            activeCam.gameObject.SetActive(false);
            activeCam = null;
            return;
        }

        trackCam.Follow = actor.transform;
        trackCam.LookAt = actor.transform;
        if(activeCam != trackCam)
            ActivateCamera(trackCam);
    }
}
