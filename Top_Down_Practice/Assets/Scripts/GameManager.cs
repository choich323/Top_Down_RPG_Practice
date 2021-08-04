using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scan_object;

    // 현재 액션 실행중인가
    public bool isAction;

    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        if (isAction)   // Exit Action
        {
            isAction = false;
        } 
        else            // Enter Action
        {
            isAction = true;
            scan_object = scanObj;
            talkText.text = scan_object.name + "(이)가 있다.";
        }

        talkPanel.SetActive(isAction);  // 액션키를 누르면 대화창을 활성화
    }
}
