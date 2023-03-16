using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject firingPoint;
    public int ammo;
    public int shieldPoints;
    public bool pointing;
    public float firerate;

    void Start()
    {
        shieldPoints = 0;
        pointing = false;
        lifePoints = 100;
        ammo = 30;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo < 30)
            {
                StartCoroutine(Recharge());
            }
            else
            {
                //text enseñando municion al maximo
            }

        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Debug.DrawRay()
            pointing = true;
        }
        else
        {
            pointing = false;
        }

        if (Input.GetKey(KeyCode.Mouse0) && pointing)
        {
            firerate += Time.deltaTime;
            while (ammo > 30)
            {
                if (firerate > 0.25f)
                {
                    Attack();
                    ammo = ammo - 1;
                }

            }
        }
    }

    public override void Attack()
    {
        RaycastHit hit;
        Physics.Raycast(firingPoint.transform.position, firingPoint.transform.right, 100);


        if (Physics.Raycast(firingPoint.transform.position, firingPoint.transform.forward, out hit , 100))
        {

            if (hit.transform.tag == "enemy")
            {
                Vector3 distance = firingPoint.transform.position - hit.transform.position;

                int criticalProbability = Random.Range(1, 25);

                if (distance.magnitude > 90)
                {
                    damage = 5;

                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if (distance.magnitude > 70 && distance.magnitude < 90)
                {
                    damage = 10;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if (distance.magnitude > 50 && distance.magnitude < 70)
                {
                    damage = 15;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if (distance.magnitude > 30 && distance.magnitude < 50)
                {
                    damage = 20;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if (distance.magnitude > 10 && distance.magnitude < 30)
                {
                    damage = 25;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

                if (distance.magnitude < 10)
                {
                    damage = 40;
                    if (criticalProbability == 1)
                    {
                        int criticalDamage = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamage;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damage;
                    }
                }

            }
            if (hit.transform.tag == "enemyHead")
            {
                Vector3 distance = firingPoint.transform.position - hit.transform.position;
                int damageHead = damage * 2;
                int criticalProbability = Random.Range(1, 25);

                if (distance.magnitude > 90)
                {
                    damage = 5;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 70 && distance.magnitude < 90)
                {
                    damage = 10;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 50 && distance.magnitude < 70)
                {
                    damage = 15;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 30 && distance.magnitude < 50)
                {
                    damage = 20;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude > 10 && distance.magnitude < 30)
                {
                    damage = 25;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
                if (distance.magnitude < 10)
                {
                    damage = 40;
                    if (criticalProbability == 1)
                    {
                        int criticalDamageHead = damage * 2;
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - criticalDamageHead;
                    }
                    else
                    {
                        Enemy enemyScript = hit.transform.GetComponent<Enemy>();
                        enemyScript.lifePoints = enemyScript.lifePoints - damageHead;
                    }
                }
            }
        }
    }

        IEnumerator Recharge()
        {
            //animator.setbool()

            yield return new WaitForSeconds(4);
            ammo = 30;
        }
    }


