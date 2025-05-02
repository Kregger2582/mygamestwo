using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        string HitDetection = other.GetComponent<Collider>().tag;

        switch(HitDetection)
        {
            case "Enemy":
                other.GetComponent<ZombiesAttributes>().TakeDamage(damage);
                Destroy(gameObject);
            break;
            case "WizardZombie":
                other.GetComponent<WizardAttributes>().TakeDamage(damage);
                 Destroy(gameObject);
            break;
            case "GiantZombie":
                other.GetComponent<GiantZombieBehiavor>().TakeDamage(damage);
                Destroy(gameObject);
            break;
            
        }
       
        
        //destroys bullet if it collides with something other then the Enemy tag
        if(!other.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
