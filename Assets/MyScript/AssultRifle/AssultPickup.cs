using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultPickup : MonoBehaviour
{
    public GameObject realAssualt;              //สำหรับปืนที่จะอยู่บนมือ
       
    public GameObject realHandgun;              //ปืนที่ 2
    public GameObject realDualHandgun;          //ปืนที่ 3
    public GameObject realShotgun;               //ปืนที่ 4
    public static bool isARbought = false;       //ตรวจสอบว่า ลูกซอง ถูกเก็บรึนัง
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(isARbought == true)
        {
            if(Input.GetButtonDown("Weapon4") && GunChanger.canChangeGun == true)       //ถ้าสถานะ Global สำหรับการเปลี่ยนปืนเป็นค่า True จะเปลี่ยนได้
            {
                realShotgun.SetActive(false);                //เปิดปืนลูกซอง
                realDualHandgun.SetActive(false);           //ปิดปืนพกคู่
                realHandgun.SetActive(false);               //ปิดปืนพกเดี่ยว
                realAssualt.SetActive(true);                 //ปืน AR
            }  
        }
    }
}
