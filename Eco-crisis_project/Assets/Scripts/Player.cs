using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :Character
{
    public GameObject firingPoint;
    public int ammo;
    public bool pointing;
    public float firerate;

    void Start()
    {
        pointing = false; 
        lifePoints = 100;
        ammo = 30;
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           // Debug.DrawRay()
            pointing = true; 
        }else
        {
            pointing = false;
        }

        if (Input.GetKey(KeyCode.Mouse1) && pointing)
        {
            firerate += Time.deltaTime;
            while (ammo > 30)
            {
                if(firerate > 0.25f)
                {            
                 Attack();
                ammo = ammo - 1;
                }

            }
        }
    }

    public override void Attack()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(firingPoint.transform.position, firingPoint.transform.right, 100);
        
        for (int i = 0; i < hits.Length; i++)
        {
           Vector3 distance = firingPoint.transform.position - hits[i].transform.position;
           
            if (hits[i].transform.tag == "enemy")
            {
                
              
            }
            if (hits[i].transform.tag == "enemyHead")
            {
                int damageHead = damage * 2;
                
            }
        }
    }
}
