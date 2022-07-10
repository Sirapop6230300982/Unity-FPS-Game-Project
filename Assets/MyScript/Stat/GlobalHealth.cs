using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public GameObject medkitDisplay;
    public static int globalHealth;
    public static int globalMedkit;

   // public int theHealth; เอาไว้ดูใน Inpector
    // Start is called before the first frame update
    void Start()
    {
        globalHealth = 100;
        globalMedkit = 0;
        EndGame.usedMedkit = 0;
        if(AchivementData.isWNHPassed)
        {
            globalMedkit = 20 ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.GetComponent<Text>().text =  "" + globalHealth ;
        medkitDisplay.GetComponent<Text>().text =  "" + globalMedkit ;
        //theHealth = globalHealth;
        if(globalHealth <= 0)
        {
            SceneManager.LoadScene(2); // Load Scene ตามที่เรียงไว้ตรง Build Setting
        }

        if(Input.GetButtonDown("Medkit") && globalMedkit > 0)
        {
            globalHealth += 75;
            if(globalHealth >= 100)
            {
                globalHealth = 100;
            }
            globalMedkit -= 1;
            EndGame.usedMedkit += 1 ;      //เก็บค่ากระสุนจาก Global
        }
        Debug.Log( EndGame.usedMedkit);
    }
}
