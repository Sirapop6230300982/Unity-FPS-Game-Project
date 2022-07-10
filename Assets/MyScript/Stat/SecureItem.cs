using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecureItem : MonoBehaviour
{
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
        GlobalScore.global_SecureScore += GlobalScore.global_Score;
        AchivmentSetting.All_I_Got += (GlobalScore.global_Score / 5);
        GlobalScore.global_Score = 0 ;
        GlobalScore.carrying_Limited = 0 ;
        
    }
}
