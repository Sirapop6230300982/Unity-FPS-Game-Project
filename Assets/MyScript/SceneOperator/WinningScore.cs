using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class WinningScore : MonoBehaviour
{
    public GameObject winScoreDisplay;
    public static int global_winScore;
    // Start is called before the first frame update
    void Start()
    {
        global_winScore = GlobalScore.global_SecureScore;
    }

    // Update is called once per frame
    void Update()
    {
        winScoreDisplay.GetComponent<Text>().text =  "" + global_winScore ;
    }
}
