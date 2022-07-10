using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ทำ UI ห้ามลืม
using UnityEngine.SceneManagement; // สำหรับ สลับ Scene

public class ShoppingSector : MonoBehaviour
{
    public GameObject BoughtDisplay;
    public GameObject MoneyDisplay;
    
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

         MoneyDisplay.GetComponent<Text>().text =  "" +  EndGame.scoreForShopping; 

         if(AssultPickup.isARbought == true)
         {
             BoughtDisplay.GetComponent<Text>().text =  "" +  "Sold Out"; 
         }
    }

    public void BuyAssault()
    {
        if(EndGame.scoreForShopping >= 20)
        {
            AssultPickup.isARbought = true ;
            
            EndGame.scoreForShopping -= 20; 
        }
    }
}
