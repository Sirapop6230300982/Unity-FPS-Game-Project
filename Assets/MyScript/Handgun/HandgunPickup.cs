using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun;          //สำหรับปืนที่จะอยู่บนมือ
    public GameObject realDualHandgun;
    public GameObject dropHandgun;          //สำหรับปืนที่อยู่ที่พื้น
    public AudioSource pickupSound;         //เสียงเก็บ
    public GameObject realShotgun;
    public GameObject realAssualt;              //ปืนที่ 4
    private bool isHandgunPicked = false;
    public static int handgunCount;

    void Start()
    {
        handgunCount = 0 ;
    }

    
    void Update()
    {
        if(isHandgunPicked == true)
        {
            if(Input.GetButtonDown("Weapon1") && GunChanger.canChangeGun == true)
            {
                realHandgun.SetActive(true);
                realDualHandgun.SetActive(false);
                realShotgun.SetActive(false);
                realAssualt.SetActive(false);
               
            }  
            else if(Input.GetButtonDown("Weapon2") && handgunCount == 2 && GunChanger.canChangeGun == true)
            {
                realDualHandgun.SetActive(true);
                realHandgun.SetActive(false);
                realShotgun.SetActive(false);
                realAssualt.SetActive(false);
            }
                //ทำให้ปืนใน FPS Character นั้นเปิดเป็น Active เพื่อให้ปืนโผล่มา
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        dropHandgun.SetActive(false);                   //ทำให้เปืนที่อยู่บนพื้นหายไป
        pickupSound.Play();                             //เล่นเสียงตอนเก็บปืน
        GetComponent<BoxCollider>().enabled = false;        
        isHandgunPicked = true;
        handgunCount += 1;
    }
}
