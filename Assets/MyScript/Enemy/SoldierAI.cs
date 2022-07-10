using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public string hitTag;                           //ตรวจสอบว่า Tag อะไรอยุ่
    public bool lookingAtPlayer = false ;           //สำหรับตรวจสอบ DebugLog ว่าศัตรูเห็นเราไหม
    public GameObject theSoldier ;                  //สำหรับ Model Soldier
    public AudioSource fireShot;                    //สำหรับรับเสียงปืนเข้ามา
    public bool isFire = false ;                    //ทำให้ศัตรูไม่เกิดการยิงซ้ำซ้อน
    public float fireRate = 1.0f;                   //ความเร็วในการยิงปืนของศัตรู
    public int missShot ;                           //สำหรับรับค่า Random ไว้ใข้ในการสร้างความเเม่นยำของศัตรู
    public float targetDistance;                    //สำหรับรับค่า Distance ของ Player ที่ห่างออกไป
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))     //ฟังก์ฺชันาำหีะยเก็บค่า Raycast ว่าศัตรูมองไปทางฝั่งไหนและผลออกมาเป็นค่า Hit
        {
            hitTag = Hit.transform.tag;         //Raycast ทำหน้าที่ตรวจจับว่า มี Tag ที่มันต้องการจะเจอรึเปล่า ถ้าเข้ามาใน Zone มันไหม ถ้าเข้า มันจะเปลี่ยนค่าตรงนี้
            targetDistance = Hit.distance;      //เก็บค่า Distance ที่ศัตรูได้หันไปหา
        }
        if(hitTag == "Player" && isFire == false)   //ถ้า Tag ที่มันเจอจาก Raycast เป็น Player และเหตุผลที่ต้องทำให้เป็น False เพราะ ว่า ระหว่างที่ยิง อยู่ จะเป็น True จะได้ไม่ทับกันและ รัวเกินไป เพราะกำลังยิงอยู่
        {
           StartCoroutine(EnemyAttack());       //ถ้าเจอ Player ก็ยิงปืนใส่
        }
        if(hitTag != "Player")                   //ถ้า Tag ไม่ใช่ Player
        {
            theSoldier.GetComponent<Animator>().Play("Idle");   //ถ้าไม่เจอ ก็จะยืนนิ่งๆ
            lookingAtPlayer = false;                            //ตรวจสอบว่า ตอนนี้ไม่ได้มอง Player ดังนั้นเป็น False
        }

        IEnumerator EnemyAttack()
        {
            isFire = true;                                                          //ศัตรูจะต้องรู้ว่าตอนนี้ยิงปืนอยู่
            theSoldier.GetComponent<Animator>().Play("FirePistol", -1, 0);          //เล่น Animation Fire pistol (-1 เป็น Step ที่จะย้อนกลับของ Animation และ 0 เป็นจุดที่จะหยุดนับ)
            theSoldier.GetComponent<Animator>().Play("FirePistol");                 //เล่น Animation
            lookingAtPlayer = true;                                                 //ตั้งค่าว่า LookingAtPlayer เป็น True
            fireShot.Play();                                                        //เล่นเสียงยิงปืน
            missShot = Random.Range(0, 11);                                         //สุ่มค่าที่จะได้ว่า จะยิงเราพลาด ในหน่วยที่เท่าไหร่
            if(missShot > 8 && targetDistance >= 11)                                //ถ้าสุ่มได้ค่ามากกว่า 8 และความไกลที่ได้จาก Raycast มีค่ามากกว่า 11 
            {
                GlobalHealth.globalHealth -= 5;             //จะทำให้ลดค่าเลือดของ Player ที่เป็นค่า Global ออกไป 5
            }
            if(missShot > 2 && targetDistance > 3 && targetDistance < 11)           //ถ้า MissShot มากกว่า 3 และ targetDistance อยู่ระหว่าง 3 ถึง 11
            {
                GlobalHealth.globalHealth -= 5;             //จะทำให้ลดค่าเลือดของ Player ที่เป็นค่า Global ออกไป 5                                 
            }
            else if(missShot > 0 && targetDistance <= 3)                            //missShot มากกว่า 0 และ targetDistance น้อกว่าเท่ากับ 3
            {
                GlobalHealth.globalHealth -= 10;            //จะทำให้ลดค่าเลือดของ Player ที่เป็นค่า Global ออกไป 10 เนื่องจากยิงในระยะ เผาขน   
            }
            yield return new WaitForSeconds(fireRate);      //ปรับเวล Delay ออกไปตาม FireRate
            isFire = false;                                 //ปรับให้ศัตรูรู้ว่าตัวเองหยุดยิงแล้ว
        }
    }
}
