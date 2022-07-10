using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class AchivmentSetting : MonoBehaviour
{
    public static int First_Time_Huh = 0;
    public GameObject First_Time_Huh_Display;
    public  int savedFTH ;
    public static int Gone_In_Thirty = 0;
    public GameObject Gone_In_Thirty_Display;
    public  int savedGIT ;
    public static int Who_Need_Health = 0;
    public GameObject Who_Need_Health_Display;
    public int savedWNH ;
    public static int Minute_Massacre = 0;
    public GameObject Minute_Massacre_Display;
    public int savedMM ;
    public static int All_I_Got = 0;
    public GameObject All_I_Got_Display;
    public int savedAIG ;
    public static int Worthless_Piece_Of_Beep = 0;
    public GameObject Worthless_Piece_Of_Beep_Display;
    public int savedWPOB ;
    public static int EndGameCount = 0 ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(First_Time_Huh == 1 && savedFTH == 0 )       //เช็คค่าว่า ผ่านครั้งแรกหรือไม่
        {
            savedFTH = 1;
            
        }
         First_Time_Huh = 0;

        if(Gone_In_Thirty == 1 && savedGIT == 0)        //เช็คว่า ผ่านภายใน 30 วินาทีหรือไม่      
        {
            savedGIT = 1;
           // Debug.Log(Gone_In_Thirty);
        }
         Gone_In_Thirty = 0;

        if(Who_Need_Health == 1 && savedWNH == 0)       //เช็คว่า มีการไม่มีใช้กล่องพยาบาลหรือไม่
        {
            savedWNH = 1;
        }
        Who_Need_Health = 0;

        if(Minute_Massacre >= 18 && savedMM == 0)       //เช็คว่า มีการปราบศัตรูครบหรือไม่
        {
            savedMM = 1;
        }
        Minute_Massacre = 0;

        if(All_I_Got >= 35 && savedAIG == 0)            //เช็คว่า เก็บแต้มครบหรือไม่
        {
            savedAIG = 1;
        }
        All_I_Got = 0;

        if(Worthless_Piece_Of_Beep >= 5 && savedWPOB == 0)      //เช็คว่าปืนขัดลำกล้องครบจำนวนหรือไม่
        {
            savedWPOB = 1 ;
        }
        Worthless_Piece_Of_Beep = 0 ;
    
        if(savedFTH == 1  || AchivementData.isFTHPassed == true)                        //ตรวจสอบว่าเราผ่านเงื่อนไขนั้นๆ มาหรือไม่
        {
            First_Time_Huh_Display.GetComponent<Text>().text =  "" +  "Completed";      //เปลี่ยนข้อความ InComplete ให้เป็น Complete
        }
         if(savedGIT == 1  || AchivementData.isGITPassed == true)
        {
            Gone_In_Thirty_Display.GetComponent<Text>().text =  "" +  "Completed";
        }
         if(savedWNH == 1  || AchivementData.isWNHPassed == true) 
        {
            Who_Need_Health_Display.GetComponent<Text>().text =  "" +  "Completed";
           
        }
         if(savedMM == 1  || AchivementData.isMMPassed == true)
        {
            Minute_Massacre_Display.GetComponent<Text>().text =  "" +  "Completed";
        }
         if(savedAIG == 1 || AchivementData.isAIGPassed == true)
        {
            All_I_Got_Display.GetComponent<Text>().text =  "" +  "Completed";
        }
         if(savedWPOB == 1  || AchivementData.isWPOBPassed == true)
        {
            Worthless_Piece_Of_Beep_Display.GetComponent<Text>().text =  "" +  "Completed";
        }
    }
}
