using UnityEngine;
using Yarn.Unity;
using Cinemachine;

public class CameraCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

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

        //get cam
        CinemachineVirtualCamera newCam = SceneObjects.GetVCam(parameters[0]);
        //Debug.Log($"{newCam} selected, param0 {parameters[0]}");
        if(activeCam != null)
        {
            activeCam.gameObject.SetActive(false);
        }

        activeCam = newCam;

        //enable/disable cam
        if(activeCam)
        {
            activeCam.gameObject.SetActive(true);
            //Debug.Log("Enabling Cam!");
        }
            
    }

    public void ResetCam()
    {
        if (activeCam == null) return;
        activeCam.gameObject.SetActive(false);
        activeCam = null;
    }
}
