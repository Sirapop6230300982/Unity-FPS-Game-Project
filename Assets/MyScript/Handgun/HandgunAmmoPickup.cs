using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunAmmoPickup : MonoBehaviour
{
    
    public GameObject dropHandgunAmmo; //สำหรับกระสุนที่อยู่ที่พื้น
    public AudioSource ammoPickupSound; //เสียงเก็บ
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        dropHandgunAmmo.SetActive(false);               //ทำให้เปืนที่อยู่บนพื้นหายไป
        ammoPickupSound.Play();                         //เล่นเสียงตอนเก็บกระสุน
        GlobalAmmo.handgunAmmo += 10 ;                  //เก็บค่ากระสุนจาก Global
        GetComponent<BoxCollider>().enabled = false;    //ทำให้ Object ที่เราไปชน ไม่จะไม่ถูกรับให้ชนอีกต่อไป

    }
}
