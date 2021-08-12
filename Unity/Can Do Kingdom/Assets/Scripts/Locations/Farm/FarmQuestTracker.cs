using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FarmQuestTracker : MonoBehaviour
{
    [Header("Jumping")]
    [SerializeField] private GameObject keys;

    [Header("Feed")]
    [SerializeField] private float feedQuestNum;
        private bool hasFeed = false;
    [SerializeField] private GameObject[] feeds;
    [SerializeField] private GameObject[] feedInteractors;
    private int animalsFed = 0;

    [Header("Watering")]
    private bool hasKey = false;

    [SerializeField] private int chestQuestNumer;
    private bool hasWateringCan = false;
    [SerializeField] private GameObject wellInteractor;
    private bool canFilled = false;
    private int plotsWatered = 0;

    private bool finished = false;

    private InMemoryVariableStorage storage;
    private DialogueRunner runner;

    private float QuestNum => storage.GetValue("$cleetusQuest").AsNumber;

    private void Awake()
    {
        storage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
        runner = FindObjectOfType<DialogueRunner>();
    }
    // Start is called before the first frame update
    
    public void GrabFeed()
    {
        if (QuestNum == feedQuestNum)
            hasFeed = true;
        else
            runner.StartDialogue("DontNeed");
    }

    public void FeedAnimal(int index)
    {
        if (!hasFeed) return;

        feeds[index].SetActive(true);
        DisableInteractor(feedInteractors[index]);
        animalsFed += 1;
        hasFeed = false;

        if (animalsFed >= 2)
        {
            IncrementQuestStep();
        }
    }
    
    public void OpenChest()
    {
        if(QuestNum != chestQuestNumer)
        {
            runner.StartDialogue("Locked");
            return;
        }
        runner.StartDialogue("WateringCan");
        hasWateringCan = true;
        wellInteractor.SetActive(true);
    }

    public void FillWateringCan()
    {
        if(hasWateringCan)
        {
            if(canFilled == true)
            {
                runner.StartDialogue("CanIsFilled");
            }
            else
            {
                runner.StartDialogue("FillCan");
                canFilled = true;
            }
        }
            
    }

    public void WaterPlot(FarmQuestPlot plot)
    {
        if (finished) return;

        if (canFilled)
        {
            plot.WaterPlot();
            plotsWatered += 1;
        }
            

        if (plotsWatered >= 8)
        {
            IncrementQuestStep();
            finished = true;
            wellInteractor.SetActive(false);
        }
            
    }

    private void IncrementQuestStep()
    {
        storage.SetValue("$cleetusQuest", new Yarn.Value(QuestNum + 1));
    }

    public void DisableInteractor(GameObject obj)
    {
        obj.transform.position = Vector3.down * 100;
    }
}
