using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Character
{
    public TMP_Text ammoText;
    public TMP_Text lifeText;
    public TMP_Text fullAmmoToast;

    public Image lifeImage;
    public Image purityImage;

    public Image pointingTarget;


    public GameObject firingPoint;

   
    public GameObject hittingParticle;
    public GameObject firing;

    ParticleSystem firingParticle;

    public Animator target;
    public Animator shield;
    public Animator playerAnimator;

    public bool pointing;
    public bool shieldActivated;

     int ammo;
    
     int maxLifePoints;
     int maxPurityPoints;
     int shieldTime;
     int shieldSeconds;
    int purityPoints;

    float firingTime;
    float fireRate;

    void Start()
    {
        firingParticle = firing.GetComponent<ParticleSystem>();
        fullAmmoToast.gameObject.SetActive(false);
        shieldActivated = false;
        fireRate = 0.25f;     
        lifePoints = 100;
        purityPoints = 100;
        maxLifePoints = 100;
        ammo = 30;
        pointing = false;    
    }


    void Update()
    {
        float life = (float)lifePoints / maxLifePoints;
        lifeImage.fillAmount = life;

        float purity = (float)purityPoints / maxPurityPoints;
        purityImage.fillAmount = purity;


        //recharge
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo < 30)
            {
                // playerAnimator.setTrigger("recharge");
                StartCoroutine(Recharge());
            }
            else
            {
                StartCoroutine(ShowFullAmmo());
            }

        }

       //pointing
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Debug.DrawRay()

            pointing = true;
        }
        else
        {
            pointing = false;
        }

        if (Input.GetKey(KeyCode.Mouse0) && pointing && ammo > 0)
        {
            firingParticle.Play();

            firingTime += Time.deltaTime;
            while (ammo > 30)
            {
                if (firingTime > fireRate)
                {
                    Attack();
                    ammo = ammo - 1;
                    ammoText.text = "" + ammo;
                }

            }
        }
        else
        {
            firingTime = 0;
            firingParticle.Stop();
        }

        if(lifePoints > 75)
        {
            fireRate = 0.25f;
        }
        if(lifePoints < 50 && lifePoints > 25)
        {
            fireRate = 0.5f;
        }
        if(lifePoints < 25)
        {
            fireRate = 1f;
        }
    }

    public override void Attack()
    {
        RaycastHit hit;
        Physics.Raycast(firingPoint.transform.position, firingPoint.transform.right, 100);


        if (Physics.Raycast(firingPoint.transform.position, firingPoint.transform.forward, out hit , 100))
        {
            if (hit.transform.tag == "scene")
            {               
                GameObject hittingParticleEffect = Instantiate(hittingParticle, hit.transform.position, hittingParticle.transform.rotation);
                hittingParticleEffect.GetComponent<ParticleSystem>().Play();
                Destroy(hittingParticleEffect, 2);
            }
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
        yield return new WaitForSeconds(4);
            ammo = 30;
        }

    IEnumerator ShowFullAmmo()
    {
        fullAmmoToast.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        fullAmmoToast.gameObject.SetActive(false);
    }

    IEnumerator ShieldActive()
    {
        shieldActivated = true;
        shield.SetBool("shield", true);
        while(shieldSeconds < shieldTime)
        {
            yield return new WaitForSeconds(1);
            shieldSeconds = shieldSeconds + 1;
        }

        shield.SetBool("shield", false);
    }


    }


