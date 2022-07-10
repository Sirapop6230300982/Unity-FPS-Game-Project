using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitPickup : MonoBehaviour
{
    public GameObject dropMedkit; //สำหรับกระสุนที่อยู่ที่พื้น
    public AudioSource pickUpSound; //เสียงเก็บ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        dropMedkit.SetActive(false);   //ทำให้เปืนที่อยู่บนพื้นหายไป
        pickUpSound.Play();             //เล่นเสียงตอนเก็บกระสุน
        GlobalHealth.globalMedkit += 1 ;      //เก็บค่ากระสุนจาก Global
        GetComponent<BoxCollider>().enabled = false;   //ทำให้ Object ที่เราไปชน ไม่จะไม่ถูกรับให้ชนอีกต่อไป

    }
}
