using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGem : MonoBehaviour
{
    public GameObject dropYellowGem; //สำหรับปืนที่จะอยู่บนมือ
    public AudioSource pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        AchivmentSetting.All_I_Got = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(GlobalScore.carrying_Limited <6)
        {
            dropYellowGem.SetActive(false);   
            pickupSound.Play();     
            GetComponent<BoxCollider>().enabled = false;
            GlobalScore.global_Score += 5 ;
            GlobalScore.carrying_Limited += 1;
            
        }
    }
}
