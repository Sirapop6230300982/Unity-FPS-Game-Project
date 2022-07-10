using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม

public class EndTimeDisplay : MonoBehaviour
{
    float Endingtime;
     public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        Endingtime = TimerSet.timerEnd;
    }

    // Update is called once per frame
    void Update()
    {
         DisplayTimer(Endingtime);
    }
     void DisplayTimer(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
