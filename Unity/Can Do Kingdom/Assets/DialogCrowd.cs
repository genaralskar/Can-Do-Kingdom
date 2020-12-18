using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogCrowd : MonoBehaviour
{
    public GameObject dialogBubblePrefab;
    private List<DialogBubbleCrowd> dialogBubbles = new List<DialogBubbleCrowd>();

    public List<string> dialogs;
    public List<Transform> dialogLocations;
    private List<Transform> openLocations;
    private List<Transform> closedLocations = new List<Transform>();

    public int totalDialogBubbles = 4;
    public float dialogBubbleTime = 5f;

    public bool runOnStart = false;
    public bool randomizeDialogs = false;
    public bool stopWhenOutOfDialog = false;

    public UnityEvent OnCrowdDialogStart;
    public UnityEvent OnCrowdDialogEnd;

    private int currentDialogIndex = 0;
    private int currentBubbleIndex = 0;
    private bool stopDialog = false;

    private void Awake()
    {
        for(int i = 0; i < totalDialogBubbles; i++)
        {
            GameObject newBubble = Instantiate(dialogBubblePrefab);
            newBubble.SetActive(false);
            dialogBubbles.Add(newBubble.GetComponent<DialogBubbleCrowd>());
        }
        openLocations = dialogLocations;
    }

    private void Start()
    {
        if(runOnStart)
            StartCrowdDialog();
    }

    public void StartCrowdDialog()
    {
        foreach (var b in dialogBubbles)
        {
            PlaceBubble(GetRandomPositon(), GetDialog());
        }
        StartCoroutine(BubbleTimer());
        OnCrowdDialogStart.Invoke();
    }

    public void StopCrowdDialog()
    {
        StopAllCoroutines();
        foreach(var b in dialogBubbles)
        {
            Debug.Log("Deactivate!");
            b.gameObject.SetActive(false);
        }
        OnCrowdDialogEnd.Invoke();
    }

    private void PlaceBubble(Transform location, string dialog)
    {
        DialogBubbleCrowd newBubble = GetBubble();
        newBubble.gameObject.SetActive(false);
        if(newBubble.location != null)
        {
            closedLocations.Remove(newBubble.location);
            openLocations.Add(newBubble.location);
            newBubble.location = null;
        }

        //if (stopWhenOutOfDialog && currentDialogIndex == 0)
        //{
        //    StopCrowdDialog();
        //    return;
        //}


        newBubble.transform.position = location.position;
        openLocations.Remove(location);
        closedLocations.Add(location);
        newBubble.location = location;
        newBubble.SetText(dialog);
        newBubble.gameObject.SetActive(true);
    }

    private IEnumerator BubbleTimer()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float timer = 0;
        while(true)
        {
            timer += Time.deltaTime;
            if(timer >= dialogBubbleTime)
            {
                //place a new bubble.
                if(stopDialog)
                {
                    StopCrowdDialog();
                    break;
                }
                PlaceBubble(GetRandomPositon(), GetDialog());
                timer = 0;
            }
            yield return wait;
        }
    }
    
    private DialogBubbleCrowd GetBubble()
    {
        DialogBubbleCrowd newBubble = dialogBubbles[currentBubbleIndex];

        currentBubbleIndex = (currentBubbleIndex + 1) % (dialogBubbles.Count);

        return newBubble;
    }

    public Transform GetRandomPositon()
    {
        int i = Random.Range(0, openLocations.Count);
        return openLocations[i];
    }

    public string GetDialog()
    {
        if (randomizeDialogs)
        {
            int r = Random.Range(0, dialogs.Count);
            return dialogs[r];
        }

        string rString = dialogs[currentDialogIndex];

        //overflow back to 0 if exceeding dialogs count
        currentDialogIndex = (currentDialogIndex + 1) % (dialogs.Count);
        if (stopWhenOutOfDialog && currentDialogIndex == 0) stopDialog = true;

        return rString;
    }
}
