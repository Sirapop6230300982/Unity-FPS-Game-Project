using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor; //ประกาศตัวแปร Door เป็น Object ที่อยู่ในเกม
    public AudioSource doorFX; //ประกาศตัวแปร doorFX เสียงของประตู
    //private bool SensorDoor; ตัวแปรไร้ประโยชน์
    void Start()
    {
        //SensorDoor = this.GetComponent<BoxCollider>().enabled; //ประกาศให้ว่าตัว SensorDoor ทำหน้าที่เป็น Boolean ของ BoxCollider ของตัว Sensor เปิดประตู ใช้ Function นี้ไม่ได้
    }

  
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //Method ที่จะทำให้เวลาไปอยู่ใกล้ ประตู แล้วประตูจะเปิดให้เอง
    {
        doorFX.Play();//เล่นเสียงประตูเปิด
        theDoor.GetComponent<Animator>().Play("Door_Open"); //เล่น Animation ตามที่ทำเอาไว้ คือ "Door_Open"
        this.GetComponent<BoxCollider>().enabled = false; //ทำให้ Sensor ตรวจจับการเข้าประตูถูกปิดไประยะหนึ่ง
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5); //สั่งให้รอ 5 วินาทีก่อนจะทำงานต่อไป
        doorFX.Play(); //เล่นเสียงประตูปิด
        theDoor.GetComponent<Animator>().Play("Door_Close"); //เล่น Animation ตามที่ตั้งเอาไว้ คือ "Door_Close"
        this.GetComponent<BoxCollider>().enabled = true; //ทำให้ Sensor ตรวจจับการเข้าประตูถูกเปืดมาใช้อีกครั้ง
    }

}
