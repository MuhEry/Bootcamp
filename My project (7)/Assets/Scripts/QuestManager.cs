using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    void Start()
    {
        AddQuest("Mesaj Ta��", "Krall�k A'dan B'ye mesaj ta��.");
    }

    public void AddQuest(string name, string description)
    {
        Quest newQuest = new Quest { questName = name, description = description, isCompleted = false };
        quests.Add(newQuest);
        Debug.Log("G�rev eklendi: " + name);
    }

    public void CompleteQuest(string name)
    {
        foreach (var quest in quests)
        {
            if (quest.questName == name)
            {
                quest.isCompleted = true;
                Debug.Log("G�rev tamamland�: " + name);
                break;
            }
        }
    }
}
