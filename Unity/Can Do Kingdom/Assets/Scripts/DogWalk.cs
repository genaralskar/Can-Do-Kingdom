using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalk : MonoBehaviour
{
    public AudioSource dogAudio;
    public float dogYapTime = 1f;
    public Rigidbody playerRb;
    public Rigidbody dogRb;

    public GameObject startWalkInteractor;
    public GameObject stopWalkInteractor;

    public Transform leadHand;
    public Transform leadDog;
    public LineRenderer lineRend;

    private ConfigurableJoint cj;

    private Vector3 startPos;
    private Quaternion startRot;

    private Coroutine leash;

    private void Awake()
    {
        startPos = dogRb.position;
        startRot = dogRb.rotation;
        StartCoroutine(DogYapping());

        stopWalkInteractor.transform.position = Vector3.zero * 100;
    }

    public void StartWalk()
    {
        cj = playerRb.gameObject.AddComponent<ConfigurableJoint>();
        cj.linearLimit = new SoftJointLimit { limit = 1 };
        cj.linearLimitSpring = new SoftJointLimitSpring { spring = 20 };

        cj.xMotion = ConfigurableJointMotion.Limited;
        cj.yMotion = ConfigurableJointMotion.Limited;
        cj.zMotion = ConfigurableJointMotion.Limited;

        dogRb.isKinematic = false;
        cj.connectedBody = dogRb;

        StartCoroutine(MoveInteractor(true));
        leash = StartCoroutine(UpdateLineRendererLeash());
    }

    public void StopWalk()
    {
        Destroy(cj);
        cj = null;

        dogRb.isKinematic = true;
        dogRb.MovePosition(startPos);
        dogRb.MoveRotation(startRot);

        StartCoroutine(MoveInteractor(false));
        StopCoroutine(leash);
        lineRend.enabled = false;
    }

    private IEnumerator UpdateLineRendererLeash()
    {
        lineRend.enabled = true;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        Vector3[] poses = new Vector3[] { leadHand.position, leadDog.position };
        while(true)
        {
            yield return wait;

            poses[0] = leadHand.position;
            poses[1] = leadDog.position;

            lineRend.SetPositions(poses);
        }
    }

    private IEnumerator DogYapping()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        float t = 0;
        while (true)
        {
            yield return wait;
            t += Time.deltaTime;
            if(t >= dogYapTime)
            {
                t = 0;
                dogAudio.Play();
            }
        }
    }

    private IEnumerator MoveInteractor(bool startWalk)
    {
        Vector3 loc;
        if(startWalk)
        {
            loc = startWalkInteractor.transform.position;
            startWalkInteractor.transform.position = Vector3.down * 100;
        }
        else
        {
            loc = stopWalkInteractor.transform.position;
            stopWalkInteractor.transform.position = Vector3.down * 100;
        }

        yield return new WaitForSeconds(10f);

        if(startWalk)
        {
            stopWalkInteractor.transform.position = loc;
        }
        else
        {
            startWalkInteractor.transform.position = loc;
        }
    }
}
