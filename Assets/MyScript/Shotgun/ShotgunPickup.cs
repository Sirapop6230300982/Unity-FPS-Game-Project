using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour
{
    public GameObject realShotgun;              //สำหรับปืนที่จะอยู่บนมือ
    public GameObject dropShotgun;              //สำหรับปืนที่อยู่ที่พื้น
    public AudioSource pickupSound;             //เสียงเก็บ
    public GameObject realHandgun;              //ปืนที่ 2
    public GameObject realDualHandgun;          //ปืนที่ 3
    public GameObject realAssualt;              //ปืนที่ 4
    private bool isShotgunPicked = false;       //ตรวจสอบว่า ลูกซอง ถูกเก็บรึนัง
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShotgunPicked == true)
        {
            if(Input.GetButtonDown("Weapon3") && GunChanger.canChangeGun == true)       //ถ้าสถานะ Global สำหรับการเปลี่ยนปืนเป็นค่า True จะเปลี่ยนได้
            {
                realShotgun.SetActive(true);                //เปิดปืนลูกซอง
                realDualHandgun.SetActive(false);           //ปิดปืนพกคู่
                realHandgun.SetActive(false);               //ปิดปืนพกเดี่ยว
                realAssualt.SetActive(false);   
            }  
        }
    }

     void OnTriggerEnter(Collider other)
    {
        dropShotgun.SetActive(false);                   //ทำให้เปืนที่อยู่บนพื้นหายไป
        pickupSound.Play();                             //เล่นเสียงตอนเก็บปืน
        GetComponent<BoxCollider>().enabled = false;    //ทำให้ BoxCollider ไม่เกิดขึั้นซ้ำอีก(ปิดไปเลย)         
        isShotgunPicked = true;                         //ทำให้โปรแกรมรู้แล้ว่าเราเก็บปืนขึ้นมาใช้แล้ว
       
    }
}
