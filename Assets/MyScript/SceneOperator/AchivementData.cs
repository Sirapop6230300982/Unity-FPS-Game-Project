using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class AchivementData : MonoBehaviour
{
    public static bool isFTHPassed;     
    public static bool isGITPassed;
    public static bool isWNHPassed;
    public static bool isMMPassed;
    public static bool isAIGPassed;
    public static bool isWPOBPassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AchivmentSetting.First_Time_Huh == 1)
        {
            isFTHPassed = true ;
        }
         if(AchivmentSetting.Gone_In_Thirty == 1 )
        {
            isGITPassed = true ;
        }
         if(AchivmentSetting.Who_Need_Health == 1 )
        {
            isWNHPassed = true ;
        }
         if(AchivmentSetting.Minute_Massacre >= 18)
        {
            isMMPassed = true ;
        }
         if(AchivmentSetting.All_I_Got >= 35)
        {
            isAIGPassed = true ;
        }
         if(AchivmentSetting.Worthless_Piece_Of_Beep >= 3)
        {
            isWPOBPassed = true ;
        }
    }
}
