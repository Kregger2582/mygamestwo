using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject slot1,slot2,WeaponHolder;
    

    private GameObject CurrentGun;

    void EquipOne()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        CurrentGun = slot1;
    }
    void EquipTwo()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        CurrentGun = slot2;
    }
    void Start()
    {
        CurrentGun = slot1;
        WeaponHolder.SetActive(false);
    }
    public void SwitchWeapons()
    {
        if(CurrentGun == slot1)
        {
            slot1.SetActive(false);
            slot1 = WeaponHolder;
            slot1.SetActive(true);
        }
        else if(CurrentGun == slot2)
        {
            slot2.SetActive(false);
            slot2 = WeaponHolder;
            slot2.SetActive(true);
        }
       
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

    