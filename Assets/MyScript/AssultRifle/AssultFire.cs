using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultFire : MonoBehaviour
{
    public GameObject modelGun;
    public GameObject gunFlash;

    private bool isFire = false;
    private bool isAim = false;
    private bool isJam = false;

    public AudioSource gunFire;
    public AudioSource emptyclip;

    public float targetDistance;

    public int damageAmount = 10 ;
    public int randomAccuracy;
    public int randomJam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButtonDown("Fire1")) //Input.GetMouseButton(1)
        {
            if(GlobalAmmo.handgunAmmo <= 0  )
            {
                emptyclip.Play();
            }
            else if(GlobalAmmo.handgunAmmo > 0 )
            {
                if(isFire == false && isAim == false && isJam == false) //HipFire
                {
                    StartCoroutine(FireShotgun()); //เมื่อไม่มีการกดปุ่ม Fire1 Coroutine จะทำหน้าที่ไม่ให้ Animation และ SFX ของปืนเกิดขึ้น
                    //transform.position = new Vector3(0.5f, -0.75f, 1.25f); ใช้ไม่ได้
                }
                else if(isJam == true)
                {
                    emptyclip.Play();
                    
                }
            
            }
           
        }
        if(isJam == true && Input.GetButtonDown("GunJam"))
        {
           
            isJam = false;
        }
    }

    IEnumerator FireShotgun()
    {
        RaycastHit theShot; 
        isFire = true ;
        if(GlobalAmmo.handgunAmmo >= 0)
        {
            GlobalAmmo.handgunAmmo -= 1 ; //ลบกระสุน และ Delay เวลา
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))//เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object)
            {
                targetDistance = theShot.distance; 
                
                theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver/*DontReq... ทำให้ไม่ว่าจะส่งค่าอะไรไปอีก Script หนึ่ง Script นี้จะไม่รับข้อมูลที่ อีกฝั่งส่งมา*/);//ส่งข้อมูลไปอีก Script
                
            }
        }
       
        modelGun.GetComponent<Animator>().Play("Assault_Shoot"); //เล่น Animation ยิง Hipfire
        gunFlash.SetActive(true); //ทำให้ Flash ปืนโผล่ออกมา
        gunFire.Play(); //เล่นเสียงปืน
        GunChanger.canChangeGun = false;
        yield return new WaitForSeconds(0.035f); // Delay เวลา เป็น 0.05 วินาที
        gunFlash.SetActive(false);//ทำให้ Flash ปืนหายไป
        yield return new WaitForSeconds(0.035f); //Delay เวลา เป็น 0.45 วินาที
        modelGun.GetComponent<Animator>().Play("Assault_Idle");  //กลับสู่สถานะเริ่มต้น
        isFire = false; //ตั้งสถานะว่ายิงไปแล้วทำให้ ตอนนี้ไม่มีการยิง Firing = False
        GunChanger.canChangeGun = true;
      
    }
}
