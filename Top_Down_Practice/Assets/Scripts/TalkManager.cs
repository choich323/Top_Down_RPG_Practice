using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // 두 개의 타입을 적어야 함(키, 밸류)

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?", "이 곳은 처음이지?" });
        talkData.Add(2000, new string[] { "이 뒤로는 갈 필요없어.", "가봤자 아무것도 없거든.", "못 믿겠으면 직접 확인해보던가." });
        talkData.Add(100, new string[] { "평범한 나무상자다." });
        talkData.Add(200, new string[] { "Luna가 준비한 책상이다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
