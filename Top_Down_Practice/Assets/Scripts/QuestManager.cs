using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("루도에게 말걸기", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("희귀한 동전?", new int[] { 5000, 2000 }));
    }


    public int GetQuestTalkIndex(int npcId)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length) // 퀘스트 대화를 모두 다 했다면 퀘스트 번호 증가
            NextQuest();

        return questList[questId].questName; // 퀘스트 이름 출력
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}
