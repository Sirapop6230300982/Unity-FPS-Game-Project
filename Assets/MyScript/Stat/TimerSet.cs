using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม

public class TimerSet : MonoBehaviour
{
    public float timeValue = 0;
    public Text timerText;
    public static float timerEnd;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
         
         timeValue += Time.deltaTime; 
         DisplayTimer(timeValue);
         timerEnd = timeValue;
       
    }
    void DisplayTimer(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
