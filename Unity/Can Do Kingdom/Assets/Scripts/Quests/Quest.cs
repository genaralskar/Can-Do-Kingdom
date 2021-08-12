using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar.quest
{

    [CreateAssetMenu(menuName = "Quest/New Quest")]
    public class Quest : ScriptableObject
    {
        public string questName;
        [Multiline]
        public string questDescription;
        public Quest[] prereqQuests;
        public int currentQuestStep;
        public QuestStep[] questSteps;

        public bool CheckPreReqs()
        {
            return false;
        }

        public void FinishQuest()
        {
            currentQuestStep = -1;
        }

        public string GetQuestStepText()
        {
            string text = "";

            if(currentQuestStep >= 1)
            {
                for(int i = 0; i < currentQuestStep; i++)
                {
                    text += $"<s>{questSteps[i].stepDescription}</s><br><br>";
                }
            }

            text += questSteps[currentQuestStep].stepDescription;

            return text;
        }
    }

    [System.Serializable]
    public struct QuestStep
    {
        public string name;
        [Multiline]
        public string stepDescription;
    }
}