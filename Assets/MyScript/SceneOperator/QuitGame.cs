using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
        
    }

    public void QuitTheGame()
    {
        
            Application.Quit();
    } 
}
