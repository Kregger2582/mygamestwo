using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//**TODO**
//bullets will not do damage and despawn




public class Gun : MonoBehaviour
{
    //gun values
    public int mag,bulletsLeft,Reserves;
    private int ammotosubract;
    public float range, ReloadTime;
    public bool HoldBotton;
    private bool shooting,reloading,readyToShoot;
    public Text ammodisplay;
    
    

    //projectile values
    public GameObject projectilePrefab; 
    public Transform shootPoint;         
    public float shootForce = 20f;

    
   
   
   

    //input system 
    // when the script starts it will say these values equal the other values
    private void Awake()
    {
        bulletsLeft = mag;
        readyToShoot = true;
    }


    //every frame it will take in inputs from MyInput
    void Update()
    {
        ammodisplay.text = $"{bulletsLeft.ToString() } / {Reserves.ToString()}";
        MyInput();

        //resets when its ready to shoot or not
        if(!shooting && bulletsLeft > 0)
        {
            readyToShoot = true;
        }
    }
    private void MyInput()
    {

        

        if(HoldBotton) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // defining reload
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < mag && !reloading && Reserves > 0 || bulletsLeft <= 0 )
        {
            reloading = true;
            Invoke("reload", 2);
        }

        if(readyToShoot && shooting && !reloading) 
        {
            
            shoot();
        }
    


    }
    
 
    private void reload()
    {
        
       ammotosubract = mag - bulletsLeft;
       
       
       
       if(ammotosubract > Reserves)
       {
            bulletsLeft = bulletsLeft + Reserves;
            Reserves = 0;
       }
       else
       {
            bulletsLeft = mag;
             Reserves = Reserves - ammotosubract;
       }
       reloading = false;
      

    }

    
    private void shoot()
    {
        if(!HoldBotton)readyToShoot = false;

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        bulletsLeft--;
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            
        }
    
       
        
    }
   


    


    
}

