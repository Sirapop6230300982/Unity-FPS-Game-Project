using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject modelGun;
    public GameObject gunFlash;

    private bool isFire = false;
    private bool isAim = false;
    private bool isJam = false;

    public AudioSource gunFire;
    public AudioSource emptyclip;

    public float targetDistance;

    public int damageAmount = 5 ;
    public int randomAccuracy;
    public int randomJam ;
    
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
                if(isFire == false && isAim == false && isJam == false ) //HipFire
                {
                    StartCoroutine(FireHandGun()); //เมื่อไม่มีการกดปุ่ม Fire1 Coroutine จะทำหน้าที่ไม่ให้ Animation และ SFX ของปืนเกิดขึ้น
                    //transform.position = new Vector3(0.5f, -0.75f, 1.25f); ใช้ไม่ได้
                }
                if(isFire == false && isAim == true && isJam == false) //SightFire
                {
                    StartCoroutine(FireHandGunSight()); //เมื่อไม่มีการกดปุ่ม Fire2 Coroutine จะทำหน้าที่ไม่ให้ Animation และ SFX ของปืนเกิดขึ้น
                    //transform.position = new Vector3(0.0f, -0.38f, 1.25f); ใช้ไม่ได้
                }
                else if(isJam == true)
                {
                    emptyclip.Play();
                    
                }
                randomJam = Random.Range(0,100);
                if(randomJam < 5 && isJam == false)
                {
                    AchivmentSetting.Worthless_Piece_Of_Beep += 1;
                    isJam = true;
                }
            }
        }
        if(Input.GetButtonDown("Fire2"))
        {
            if(isAim == false)
            {
                StartCoroutine(AimDownSight()); //สั่งให้ขึ้นศูนย์เล็งปืน
                
            }
            if(isAim == true)
            {
                StartCoroutine(AimNormal()); //สั่งให้ลดศูนย์เล็งปืน
            }
        }
         if(isJam == true && Input.GetButtonDown("GunJam"))
        {
           
            isJam = false;
        }
    }

    IEnumerator FireHandGun()
    {
        RaycastHit theShot;                                         //ประกาศตัวแปรสำหรับ Raycast
        isFire = true ;                                             //เมื่อยิงปืนได้
        GlobalAmmo.handgunAmmo -= 1 ;                               //ลบกระสุน และ Delay เวลา
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))     //เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object)
        {
            targetDistance = theShot.distance;                      //รับค่าระยะระหว่างเป้าหมายกับ Player
            randomAccuracy = Random.Range(0, 11);                   //สุ่มค่าความแม่นยำ
            if(randomAccuracy >= 6 && targetDistance > 4)           //หากระยะเป้าหมายห่างไปนมากกว่า 4 หน่วย และ ความแม่นที่สุ่มออกมา มีค่ามากกว่า 5 (คือยิงแล้วต้องลุ้นว่า โดนหรือไม่) 
            {
                theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
            }
            else if(targetDistance < 4 && randomAccuracy >= 0)      //หากระยะเป้าหมายห่างไปน้อยกว่า 4 หน่วย และ ความแม่นที่สุ่มออกมา มีค่ามากกว่า 0 (คือยิงอย่างไรก็โดน) 
            {
                theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
            }
        }
        modelGun.GetComponent<Animator>().Play("HandGun_Fire");     //เล่น Animation ยิง Hipfire
        gunFlash.SetActive(true);                                   //ทำให้ Flash ปืนโผล่ออกมา
        gunFire.Play();                                             //เล่นเสียงปืน
        GunChanger.canChangeGun = false;                            //ทำให้ทราบว่าเปลี่ยนปืนได้หรือไม่ (ไม่)
        yield return new WaitForSeconds(0.025f);                    //Delay เวลา เป็น 0.05 วินาที
        gunFlash.SetActive(false);                                  //ทำให้ Flash ปืนหายไป
       
        yield return new WaitForSeconds(0.025f);                    //Delay เวลา เป็น 0.45 วินาที
        modelGun.GetComponent<Animator>().Play("New State");        //กลับสู่สถานะเริ่มต้น
        isFire = false;                                             //ตั้งสถานะว่ายิงไปแล้วทำให้ ตอนนี้ไม่มีการยิง Firing = False
       
        GunChanger.canChangeGun = true;                             //ทำให้ทราบว่าเปลี่ยนปืนได้หรือไม่ (ได้)
    }

     IEnumerator AimNormal()
    {
        yield return new WaitForSeconds(0.05f); //Delay ด้วย IEnumerator
        isAim = false; //ให้การเล็งเป็น False
        //Debug.Log("NoAim"); สำหรับดูค่า Boolean
        modelGun.GetComponent<Animator>().Play("HandGun_NonSight"); //กลับศูนย์เล็งจาก DownSight เป็น HipFire
        
    }

    IEnumerator FireHandGunSight()
    {
        RaycastHit theShot; 
        isFire = true ;
        GlobalAmmo.handgunAmmo -= 1 ;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))//เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object)
        {
            targetDistance = theShot.distance; 
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);//ส่งข้อมูลไปอีก Script
        }
        modelGun.GetComponent<Animator>().Play("HandGun_SightFire");
        gunFlash.SetActive(true);
        gunFire.Play();
        GunChanger.canChangeGun = false;
        yield return new WaitForSeconds(0.025f);
        gunFlash.SetActive(false);
        yield return new WaitForSeconds(0.025f);
       
        modelGun.GetComponent<Animator>().Play("HandGun_HoldSight"); //ถ้าใช่้เป็น New State ปืนจะกลับไปที่ HipFire ทั้งๆที่เรายังไม่ได้สั่งให้เล็งศูนย์ปืนที่ HipFire
        isFire = false;
       
        GunChanger.canChangeGun = true;
    }
    
    IEnumerator AimDownSight()
    {   
        yield return new WaitForSeconds(0.05f);
        isAim = true;
        //Debug.Log("Aim");
        modelGun.GetComponent<Animator>().Play("HandGun_Sight");
        
    }

    

   

}
