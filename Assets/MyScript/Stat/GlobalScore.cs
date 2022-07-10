using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class GlobalScore : MonoBehaviour
{
    public GameObject scoreDisplay;
    public static int global_Score;
    public GameObject secureScoreDisplay;
    public static int global_SecureScore;
    public GameObject keyDisplay;
    public static int keyScore;
    public static int carrying_Limited;
    //public static int transfer_Score;
    // Start is called before the first frame update
    void Start()
    {
        //transfer_Score = global_SecureScore;
        global_Score = 0;
        global_SecureScore = 0;
        carrying_Limited = 0;
        keyScore = 0 ;
         AchivmentSetting.Worthless_Piece_Of_Beep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.GetComponent<Text>().text =  "" + global_Score ;
        secureScoreDisplay.GetComponent<Text>().text =  "" + global_SecureScore ;
        keyDisplay.GetComponent<Text>().text =  "" + keyScore ;
        
    }
}
