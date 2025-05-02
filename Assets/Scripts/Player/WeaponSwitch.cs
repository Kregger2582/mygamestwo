using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;


    void EquipOne()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
    }
    void EquipTwo()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            EquipOne();
        }
        if(Input.GetKeyDown("2"))
        {
            EquipTwo();
        }

    }
}
