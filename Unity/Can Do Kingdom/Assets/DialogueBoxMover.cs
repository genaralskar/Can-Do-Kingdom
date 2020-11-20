using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using genaralskar.Actor;

public class DialogueBoxMover : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private RectTransform dialogueBoxImage;
    [SerializeField]
    private float moveSpeed = 3f, paddingUp = 10f, paddingDown = 250f, paddingLeft = 320f, paddingRight = 320f;
    [SerializeField]
    private Vector2 offset = new Vector2(0, 3);
    [SerializeField]
    Transform defaultLocation;

    private Vector2 desiredPosition;
    private Actor actorToTrack;

    public void TrackActor(string name)
    {
        actorToTrack = SceneObjects.GetActorFromActorName(name);
        if(actorToTrack != null)
        {
            //got name
            StartCoroutine(MoveBox());
        }
        else
        {
            // did not get name
            if(defaultLocation == null)
            {
                SetDesiredWorldPosition(Vector2.zero);
            }
            else
            {
                SetDesiredWorldPosition(defaultLocation.position);
            }
        }
    }

    public void StopTracking()
    {
        StopAllCoroutines();
    }

    public void SetDesiredWorldPosition(Vector2 pos)
    {
        // set position with offset
        desiredPosition = pos + offset;
    }

    private Vector2 GetCurrentActorPosition()
    {
        if(actorToTrack != null)
        {
            SetDesiredWorldPosition(actorToTrack.transform.position);
            return actorToTrack.transform.position;
        }
        else
        {
            return desiredPosition;
        }
    }

    private IEnumerator MoveBox()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        while(true)
        {
            Vector2 actorPos = GetCurrentActorPosition() + offset;
            Vector2 newPos = Vector2.Lerp((Vector2)dialogueBox.transform.position, GetBoundsPos(actorPos), moveSpeed * Time.deltaTime);
            dialogueBox.transform.position = newPos;
            yield return wait;
        }
    }

    private Vector2 GetBoundsPos(Vector2 worldPosition)
    {
        //clamp to screen size
        Vector2 bPos = Camera.main.WorldToScreenPoint(worldPosition);
        float w = dialogueBoxImage.rect.width / 2;
        float h = dialogueBoxImage.rect.height / 2;
        bPos.x = Mathf.Clamp(bPos.x, paddingLeft, Camera.main.pixelWidth - paddingRight);
        bPos.y = Mathf.Clamp(bPos.y, paddingDown, Camera.main.pixelHeight - paddingUp);

        // if the box is overlapping the actor at the top of the screen, move it below the actor
        if(bPos.y - worldPosition.y <= h)
        {

        }

        return bPos;
    }
}
