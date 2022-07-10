using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemPickup : MonoBehaviour
{
    public GameObject dropBlueGem;      //สำหรับปืนที่จะอยู่บนมือ
    public AudioSource pickupSound;     //เสียงเก็บของ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)                    //เมื่อเกิดการชนระหว่าง Player และ Block Collider
    {
       
            dropBlueGem.SetActive(false);                   //Blue Gem จะหายไป
            pickupSound.Play();                             //เล่นเสียงเก็บของ
            GetComponent<BoxCollider>().enabled = false;    //ทำให้ BoxCollider ปิดไปเลย
            GlobalScore.keyScore += 1;                      //เพิ่มค่า Key ที่เป็น Global เพื่อให้รู้ว่า เก็บ Key Item แล้ว
        
    }
}
