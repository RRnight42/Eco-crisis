using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Character
{
   
    

    Image lifeImage;
    Image purityImage;

    public GameObject fullAmmoToast;
    public GameObject emptyAmmoToast;
    GameObject ShieldBarImage;
    GameObject pointingTarget;
    GameObject firingPoint; 
    
    
    GameObject shield;
    public GameObject hittingParticle;

    ParticleSystem shieldParticle;
    

    Animator targetAnimator;
    Animator shieldAnimator;
    Animator playerAnimator;

   bool pointing;
   bool shieldActivated;

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
        lifeImage = GameObject.Find("LifeBar").GetComponent<Image>();
        purityImage = GameObject.Find("PurityBar").GetComponent<Image>();

        pointingTarget = GameObject.Find("Target");
        targetAnimator = pointingTarget.GetComponent<Animator>();

        ShieldBarImage = GameObject.Find("ShieldBar");
        shieldAnimator = ShieldBarImage.GetComponent<Animator>();

        playerAnimator = this.GetComponent<Animator>();

        firingPoint = GameObject.Find("FiringPoint");

        shield = GameObject.Find("shield");
        shieldParticle = shield.GetComponent<ParticleSystem>();

        
        fullAmmoToast.gameObject.SetActive(false);
        emptyAmmoToast.gameObject.SetActive(false);

        shieldActivated = false;
        fireRate = 0.25f;     
        lifePoints = 100;
        shieldTime = 10;
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
                
                StartCoroutine(Recharge());
            }
            else
            {
                StartCoroutine(ShowFullAmmo());
            }

        }

       //pointing
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.DrawRay(firingPoint.transform.position, firingPoint.transform.right * 100, Color.red);
            playerAnimator.SetBool("pointing", true);
            targetAnimator.SetBool("pointing" , true);
            pointing = true;
        }
        else
        {
            playerAnimator.SetBool("pointing", false);
            targetAnimator.SetBool("pointing", false);
            pointing = false;
        }

        //shooting
        if (Input.GetKey(KeyCode.Mouse0) && pointing)
        { 
          if(ammo == 0)
          {
                playerAnimator.SetBool("firing", false);
              StartCoroutine(ShowEmptyAmmo());
          } else { 
            
            playerAnimator.SetBool("firing" , true);
            
            firingTime += Time.deltaTime;

            if (ammo > 0)
            {
                if (firingTime > fireRate)
                {
                    Attack();
                    ammo = ammo - 1;
                    firingTime = 0;
                }
            }                       
            }

        }
        else
        {
            playerAnimator.SetBool("firing" , false);
            firingTime = 0;
            
            
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
        playerAnimator.SetBool("firing", false);
        playerAnimator.SetBool("recharge" , true);   
        yield return new WaitForSeconds(3);
        ammo = 30;
        playerAnimator.SetBool("recharge", false);
    }

    IEnumerator ShowFullAmmo()
    {
        fullAmmoToast.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        fullAmmoToast.gameObject.SetActive(false);
    }
    IEnumerator ShowEmptyAmmo()
    {
        emptyAmmoToast.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        emptyAmmoToast.gameObject.SetActive(false);
    }

    IEnumerator ShieldActive()
    {
        shieldSeconds = 0;
        shieldActivated = true;
        shieldAnimator.SetBool("shield", true);
        shieldParticle.Play();

        while(shieldSeconds < shieldTime)
        {
            yield return new WaitForSeconds(1);
            shieldSeconds = shieldSeconds + 1;
        }

        yield return null;
        shieldActivated = false;
        shieldParticle.Stop();
        shieldAnimator.SetBool("shield", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shield")
        {
            StartCoroutine(ShieldActive());
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Healing")
        {
            if(lifePoints >= 100)
            {

            }
            else
            {
                lifePoints = lifePoints + 10;
                Destroy(other.gameObject);
                if(lifePoints >= 100)
                {
                    lifePoints = 100;
                }
            }
        }
        if(other.gameObject.tag == "Enemy")
        {
            if (shieldActivated)
            {

            }
            else
            {
                lifePoints = lifePoints - 10;
            }
        }
    }
}


