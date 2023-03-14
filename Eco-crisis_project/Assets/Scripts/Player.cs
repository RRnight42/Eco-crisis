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
          
           
            if (hits[i].transform.tag == "enemy")
            {
                Vector3 distance = firingPoint.transform.position - hits[i].transform.position;
                
                int criticalProbability = Random.Range(1, 25);

                if(distance.magnitude > 90) {
                    damage = 5;

                    if(criticalProbability == 1)
                    {
                       int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if(distance.magnitude > 70 && distance.magnitude < 90) {
                    damage = 10;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if(distance.magnitude > 50 && distance.magnitude < 70) {
                    damage = 15;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if(distance.magnitude > 30 && distance.magnitude < 50) {
                    damage = 20;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if(distance.magnitude > 10 && distance.magnitude < 30) {
                    damage = 25;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if(distance.magnitude < 10) {
                    damage = 40;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

            }
            if (hits[i].transform.tag == "enemyHead")
            {              
                Vector3 distance = firingPoint.transform.position - hits[i].transform.position;
                int damageHead = damage * 2;
                int criticalProbability = Random.Range(1, 25);

                if (distance.magnitude > 90)
                {
                    damage = 5;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 70 && distance.magnitude < 90)
                {
                    damage = 10;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 50 && distance.magnitude < 70)
                {
                    damage = 15;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 30 && distance.magnitude < 50)
                {
                    damage = 20;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 10 && distance.magnitude < 30)
                {
                    damage = 25;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude < 10)
                {
                    damage = 40;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hits[i].transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
            }
        }
    }
}
