using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class EndGame : MonoBehaviour
{
    public static int usedMedkit = 0 ;
    public static int scoreForShopping = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(GlobalScore.keyScore > 0)
        {
             SceneManager.LoadScene(3);
             scoreForShopping += GlobalScore.global_SecureScore;
        }

        if(AchivmentSetting.First_Time_Huh == 0)
        {
            AchivmentSetting.First_Time_Huh = 1 ;
        }
       
        if(TimerSet.timerEnd <= 30)
        {
            AchivmentSetting.Gone_In_Thirty = 1 ;
        }    
        if(usedMedkit == 0)
        {
            AchivmentSetting.Who_Need_Health = 1 ;
        }
    }
}
