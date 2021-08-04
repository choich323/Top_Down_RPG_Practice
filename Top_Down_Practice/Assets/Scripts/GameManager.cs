using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scan_object;

    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        scan_object = scanObj;
        talkText.text = scan_object.name + "(이)가 있다.";
    }
}
