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
    public Animator portraitAnim;
    public Sprite prevPortrait;
    public TypeEffect talk;
    public Text questText;
    public GameObject menuSet;
    public GameObject scan_object;
    public int talkIndex;

    // 현재 액션 실행중인가
    public bool isAction;

    void Start()
    {
        questText.text = questManager.CheckQuest();
    }

    void Update()
    {
        // Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
    }

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
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim) 
        { 
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        // End talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return;
        }
        // Continue talk
        if (isNPC)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1])); // Parse: 문자열을 해당 타입으로 변환시켜줌 - 단, 숫자 텍스트만 가능함
            portraitImg.color = new Color(1, 1, 1, 1);

            if (prevPortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
