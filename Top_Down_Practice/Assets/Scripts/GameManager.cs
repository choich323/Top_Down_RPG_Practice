using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Image portraitImg;
    public Text talkText;
    public GameObject scan_object;
    public int talkIndex;

    void Start()
    {
        Debug.Log(questManager.CheckQuest()); // 매개변수가 있는가 없는가에 따라 다른 함수 실행(오버로드)
    }

    // 현재 액션 실행중인가
    public bool isAction;

    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scan_object = scanObj;
        ObjData objData = scan_object.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetBool("isShow", isAction);  // 액션키를 누르면 대화창을 활성화
    }

    void Talk(int id, bool isNPC)
    {
        // Set talk data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        

        // End talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        // Continue talk
        if (isNPC)
        {
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1])); // Parse: 문자열을 해당 타입으로 변환시켜줌 - 단, 숫자 텍스트만 가능함
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
