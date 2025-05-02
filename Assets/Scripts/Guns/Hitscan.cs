using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hitscan : MonoBehaviour
{
    //bugs 
    // the line does not go in a straight line
    // its more like a continous beam then a one shot at a time weapon
    
    public int mag,bulletsLeft,damage,Reserves;
    private int ammotosubract;
    public bool HoldButton;
    public Text ammodisplay;
    public float ReloadTime, range;
    public Transform spawnPoint;
    private bool shooting,reloading;
    private float lasttimeshot = 0;
    
    public float FireRate;
    

   

    void LineDrawer()
    {
        Vector3 direction = Vector3.forward;
        Ray myRay = new Ray(spawnPoint.position,spawnPoint.TransformDirection(direction * range));
        Debug.DrawRay(spawnPoint.position,spawnPoint.TransformDirection(direction * range));

        if(Physics.Raycast(myRay, out RaycastHit hit, range))
        {
           string HitDetection = hit.collider.tag;
            
            

            switch(HitDetection)
            {
                case "Enemy":
                        
                    hit.collider.GetComponent<ZombiesAttributes>().TakeDamage(damage);
                            
                     break;    
                        
                        
                case "GiantZombie":
                    hit.collider.GetComponent<GiantZombieBehiavor>().TakeDamage(damage);
                                
                    break;
                case "Rock":
                    hit.collider.GetComponent<RockThrow>().TakeDamage(damage);
                                
                    break;
                case "WizardZombie":
                    hit.collider.GetComponent<WizardAttributes>().TakeDamage(damage);
                                
                    break;    







            }
           


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

            if(reloading)
            {
                Reserves = Reserves - ammotosubract;
            }

       }
       reloading = false;
      

    }
    void myInputs()
    {
        if(HoldButton) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if(shooting  && bulletsLeft > 0)
        {
            if(Time.time > lasttimeshot + FireRate)
            {
                lasttimeshot = Time.time;
                bulletsLeft--;
                LineDrawer();
           

            
            }
           
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < mag && !reloading && Reserves > 0 || bulletsLeft <= 0 )
        {
            reloading = true;
            Invoke("reload",ReloadTime);
        }
        
    }
    // Start is called before the first frame update
    void Awake()
    {
        bulletsLeft = mag;
       
    }

    // Update is called once per frame
    void Update()
    {
        ammodisplay.text = $"{bulletsLeft.ToString() } / {Reserves.ToString()}";
        myInputs();
        
       
    }

}
