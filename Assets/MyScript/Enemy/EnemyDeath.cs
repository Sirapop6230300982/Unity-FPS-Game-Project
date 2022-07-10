using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth = 20 ;       //Health Point ของศัตรู
    public bool enemyDeath = false;     //ตอนนี้ศัตรูยังไม่ตาย จึงมีค่าเป็น False
    public GameObject enemyAI ;         //สำหรับรับค่า Object จาก Hierachy ที่เป็นส่วยของโค้ด EnemyAI
    public GameObject theEnemy ;        //สำหรับรับค่า Object จาก Hierachy ที่เป็นส่วยของโมเดล 

    // Start is called before the first frame update
    void Start()
    {
        AchivmentSetting.Minute_Massacre = 0 ;      //Set ค่า Achievement ให้เป็นค่า 0 เพื่อป้องกันการเก็บสะสมจาก Match ที่ผ่านมา
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDeath == false && enemyHealth <= 0)                     //สำรุวจว่าศัตรูตายหรือไม่ และ เลือดเหลือ 0 หรือไม่
        {
            enemyDeath = true;                                          //ปรับให้ ตาย เป็น True
            theEnemy.GetComponent<Animator>().Play("Death");            //เล่น Animation Death
            enemyAI.SetActive(false);                                   //ทำให้ AI ถูกปิดการใช้งาน กล่าวคือ จะไม่มีการยิงใส่ตัวละคร
            theEnemy.GetComponent<LookPlayer>().enabled = false;        //ศัครูจะไม่หันตามเราแม้จะร่วงลงไปแล้ว
            theEnemy.GetComponent<BoxCollider>().enabled = false;       //ทำให้เราไม่เดินชนศพของศัตรู
            AchivmentSetting.Minute_Massacre += 1;                      //บวกค่าเพิ่อนำไปสะสมสำหรับ Achievement
        }
    }

    void DamageEnemy(int damageAmount)              //ฟังก์ชันสำหรับรับค่าจาก อีกฟังก์ชันเพื่อใช้ในการลดเลือดศัตรู
    {
        enemyHealth -= damageAmount;                //ลบหน่วยเลือดตามจำนวน Damage ที่จ่ายเข้ามาจากอีกฟังก์ชันหนึ่ง
    }
}
