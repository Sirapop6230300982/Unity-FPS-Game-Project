using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChanger : MonoBehaviour
{
    public static bool canChangeGun;
    // Start is called before the first frame update
    void Start()
    {
        canChangeGun = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(canChangeGun);
    }
}
