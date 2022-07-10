using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class RestartScene : MonoBehaviour
{
    public GameObject selfActive;
    // Start is called before the first frame update
    void Start()
    {
       //RestartTheScene();
    }

    // Update is called once per frame
    void Update()
    {
         selfActive.SetActive(false); 
    }
    void RestartTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
