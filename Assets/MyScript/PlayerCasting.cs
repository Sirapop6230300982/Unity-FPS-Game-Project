using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceTarget; //ระยะจากเป้าหมายที่จะยิง
    public float toTarget; //ยิงถึงเป้าหมาย
    
    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))//เราจะตรวจสอบว่าเราไกลเท่าไหร่จาก Object        
        {
            toTarget = Hit.distance; //toTarget รับค่าว่า Hit ไกลเท่าไหร่
            distanceTarget = toTarget; //ให้ distanceTarget เป็นค่าเดียวกับ toTarget
        }
    }
}
