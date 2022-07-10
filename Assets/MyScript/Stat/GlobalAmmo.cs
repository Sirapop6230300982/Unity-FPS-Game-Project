using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int handgunAmmo;  //Static ทำให้เราสามารถ Access Variable จาก Script อื่นๆได้ (ทำให้ค่าเป็น Global)
    public GameObject ammoDisplay;  //ไว้ใช้ Display ค่า handgunAmmo ไว้ใน UI
    
    void Start()
    {
        handgunAmmo = 0 ;       //Set ไว้ให้เป็น 0 ทุกครั้งที่เริิ่มใหม่
        if(AchivementData.isAIGPassed == true)
        {
            handgunAmmo = 100;
        }
    }

    
    void Update()
    {
        ammoDisplay.GetComponent<Text>().text = "" + handgunAmmo;   //ทำให้เกืดข้อความตามกระสุนที่มีอยู่
    }
}
