using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDualHandgun : MonoBehaviour
{
    public GameObject modelGun;             //สำหรับเซ็ตค่า Model ของปืน                 
    public GameObject gunFlash1;            //แสง Flash จากปืนกระบอกที่ 1
    public GameObject gunFlash2;            //แสง Flash จากปืนกระบอกที่ 2
    public GameObject selfGun;              //ตัวปืนเอง(ไม่ได้ใช้)

    private bool isFire = false;            //ตรวจสอบว่าตอนนี้ยิงปืนหรือไม่
    private bool isAim = false;             //ตรวจสอบว่าตอนนี้เล็งขึ้นศูนย์ปืนหรือไม่
    private bool isJam = false;             //ตรวจสอบว่าปืนขัดลำกล้องหรือไม่

    public AudioSource gunFire;             //สำรหับเล่นเสียงยิงปืน
    public AudioSource emptyclip;           //สำหรับเสียงกระสุนหมด

    public float targetDistance;            //สำหรับรับค่าว่า Distance ห่างจากศัตรูเท่าไหร่

    public int damageAmount = 5 ;
    public int randomAccuracy;              //สำหรับรับค่าสุ่มของความแม่นยำ
    public int randomJam;                   //สำหรับรับค่าว่าปืนจะขัดลำกล้องหรือไม่

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(GlobalAmmo.handgunAmmo <= 0)
            {
                emptyclip.Play();
            }
            else if(GlobalAmmo.handgunAmmo > 0)
            {
                if(isFire == false && isAim == false && isJam == false) // การยิงแบบ HipFire
                {
                    StartCoroutine(FireHandGun()); //เมื่อไม่มีการกดปุ่ม Fire1 Coroutine จะทำหน้าที่ไม่ให้ Animation และ SFX ของปืนเกิดขึ้น
                    //transform.position = new Vector3(0.5f, -0.75f, 1.25f); ใช้ไม่ได้
                }
                else if(isJam == true )                                    //ถ้าปืนขัดลำกล้องจะยิงไม่ออกและมีเสียงปืนขัดลำกล้อง
                {
                    emptyclip.Play();           
                    
                }
                randomJam = Random.Range(0,100);                            //สุ่ม RandomJam จาก 0 - 100
                if(randomJam < 3 && isJam == false)                         //สุ่มค่าจาก randomJam ว่าปืนจะขัดลำกล้องหรือไม่
                {
                    AchivmentSetting.Worthless_Piece_Of_Beep += 1;          //บวกค่า Achievement สำหรับนำไปสะสม
                    isJam = true;                                           //ทำให้ปืนขัดลำกลอ้ง
                }
              
            }
        }
        

        if(isJam == true && Input.GetButtonDown("GunJam"))              //ถ่้าปืนขัดลำกล้องให้กดปุ่ม G จะทำให้ปืนหายขัดลำกล้อง
        {
           
            isJam = false;                                                          
            //Self.SetActive(true);
        }
    }

    IEnumerator FireHandGun()
    {
        RaycastHit theShot; 
        isFire = true ;
        if(GlobalAmmo.handgunAmmo == 1)       
        {
            GlobalAmmo.handgunAmmo -= 1 ;                           //ลดกระสุนปืน
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))//เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object)
            {
                targetDistance = theShot.distance;                  //รับค่าว่า Distance ที่ได้ออกมาจาก Raycast ห่างเท่าไหร่
                randomAccuracy = Random.Range(0, 11);               //สุ่มค่าความแม่นยำว่าจะยิงโดนหรือไม่
                if(randomAccuracy >= 4 && targetDistance >= 4)      
                {
                    theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
                    //ส่งค่าไปหา Function DamageEnemy ว่ามีค่าอะไรส่งไปบ้าง กล่าวคือ ส่ง DamageAmount ไป ทำให้ ศัตรูเลือดลด
                }
                else if(targetDistance < 4 && randomAccuracy >= 0)
                {
                    theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
                    //ส่งค่าไปหา Function DamageEnemy ว่ามีค่าอะไรส่งไปบ้าง กล่าวคือ ส่ง DamageAmount ไป ทำให้ ศัตรูเลือดลด
                }
            }
        }
        else if(GlobalAmmo.handgunAmmo > 1)
        {
            GlobalAmmo.handgunAmmo -= 2 ;                           //ลบกระสุน
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))     //เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object)
            {
                targetDistance = theShot.distance;                  //รับค่าว่า Distance ที่ได้ออกมาจาก Raycast ห่างเท่าไหร่
                randomAccuracy = Random.Range(0, 11);               //สุ่มค่าความแม่นยำว่าจะยิงโดนหรือไม่
                if(randomAccuracy >= 4 && targetDistance >= 4)
                {
                    theShot.transform.SendMessage("DamageEnemy", damageAmount+5, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
                    //ส่งค่าไปหา Function DamageEnemy ว่ามีค่าอะไรส่งไปบ้าง กล่าวคือ ส่ง DamageAmount ไป ทำให้ ศัตรูเลือดลด
                }
                else if(targetDistance < 4 && randomAccuracy >= 0)
                {
                    theShot.transform.SendMessage("DamageEnemy", damageAmount+5, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
                    //ส่งค่าไปหา Function DamageEnemy ว่ามีค่าอะไรส่งไปบ้าง กล่าวคือ ส่ง DamageAmount ไป ทำให้ ศัตรูเลือดลด
                }
            }
        }
        
        modelGun.GetComponent<Animator>().Play("HandGun_Fire2");    //เล่น Animation ยิง Hipfire
        gunFlash1.SetActive(true);                                  //ทำให้ Flash ปืนโผล่ออกมา
        gunFire.Play();                                             //เล่นเสียงปืน
        GunChanger.canChangeGun = false;
        yield return new WaitForSeconds(0.015f);
        gunFlash2.SetActive(true);                                  //ทำให้ Flash ปืนโผล่ออกมา
        gunFire.Play();                                             //เล่นเสียงปืน
        yield return new WaitForSeconds(0.015f);                    // Delay เวลา เป็น 0.05 วินาที
        gunFlash1.SetActive(false);                                 //ทำให้ Flash ปืนหายไป
        gunFlash2.SetActive(false);
        
        yield return new WaitForSeconds(0.15f);                     //Delay เวลา เป็น 0.45 วินาที
        modelGun.GetComponent<Animator>().Play("New State");        //กลับสู่สถานะเริ่มต้น
        isFire = false;                                             //ตั้งสถานะว่ายิงไปแล้วทำให้ ตอนนี้ไม่มีการยิง Firing = False
        
        GunChanger.canChangeGun = true;                             //ค่า Global ที่บอกว่า สถานะตอนนี้เปลี่ยนปืนได้แล้ว
    }


    

   

}
