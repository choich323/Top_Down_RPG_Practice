using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // 두 개의 타입을 적어야 함(키, 밸류)
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        // 대화
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳은 처음이지?:2" });
        talkData.Add(2000, new string[] { "이 뒤로는 갈 필요없어.:0", "가봤자 아무것도 없거든.:1", "못 믿겠으면 직접 확인해보던가.:2" });
        
        talkData.Add(100, new string[] { "평범한 나무상자다." });
        talkData.Add(200, new string[] { "Luna가 준비한 책상이다." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와.:0", "이 곳은 처음이지?:2", "아직 조촐한 단계지만, 점점 발전할거야.:1", "우선 저기 오른쪽의 루도에게 가봐.:0" });
        talkData.Add(11 + 2000, new string[] { "또 루나가 나한테 오라고 했나보군.:0", "아쉽지만 이 다음은 정해지지 않아서 말이야.:1", "힘들게 왔는데 미안하게 됐군.:0" });

        // 초상화
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
