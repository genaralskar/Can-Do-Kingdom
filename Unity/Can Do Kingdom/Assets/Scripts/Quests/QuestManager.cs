using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace genaralskar.quest
{
    public class QuestManager : MonoBehaviour
    {
        public List<Quest> quests;

        public Quest testQuest;
        public TextMeshProUGUI text;

        private void Update()
        {
            DisplayQuestSteps(testQuest);
        }

        public void IncrementQuestStep(Quest quest)
        {
            
        }

        public void IncrementQuestStep(string questName)
        {
            IncrementQuestStep(FindQuestByName(questName));
        }

        private Quest FindQuestByName(string name)
        {
            return quests.Find(x => x.name == name);
        }

        public void DisplayQuestSteps(Quest quest)
        {
            text.text = quest.GetQuestStepText();
        }
    }
}