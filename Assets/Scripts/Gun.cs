using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    int gunDamageLevel;
    public int [] gunDamageArray;
    int gunMagazineSizeLevel;
    public int[] gunMagazineSizeArray;
    int gunReloadSpeedLevel;
    public float[] gunReloadSpeedArray;

    int baseGunDamage;
    public int gunMasteryVariable;
    public int critChance;
    public int critDamage = 150;

    public int fireRate;
    int bulletsAvailable, magazineSize;
    float reloadTime;

    public int totalBullets;


    bool shoot;
    
    bool canReload = true;
    bool isReloading;
    
    public Transform firePosition;
    
    public GameObject muzzleFlash, bulletHole, robotHitEffect;

    public GunTypes gunType;

    [SerializeField] Camera fpsCamera;
    //recoil
    Recoil recoilScript;
    VisualRecoil visualRecoilScript;

    //UI
    public TextMeshProUGUI AmmoUI;

    private void Awake()
    {
        baseGunDamage = gunDamageArray[gunDamageLevel];
        bulletsAvailable = magazineSize = gunMagazineSizeArray[gunMagazineSizeLevel];
        reloadTime = gunReloadSpeedArray[gunReloadSpeedLevel];

        recoilScript =  FindObjectOfType<Recoil>();
        visualRecoilScript = FindObjectOfType<VisualRecoil>();
        AmmoUI.text = string.Format(bulletsAvailable + "/" + totalBullets);
    }

    public void Shoot(bool _shoot)
    {
        if (_shoot == true && Time.timeScale != 0)
        {
            shoot = true;
            StartCoroutine(ShootRoutine());
        }
        else
        {
            shoot = false;
        }
    }

    public void Reload()
    {
        if (canReload && bulletsAvailable != magazineSize && totalBullets != 0)
        {
            isReloading = true;
            canReload = false;
            StartCoroutine(ReloadRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        while (shoot && bulletsAvailable > 0 && !isReloading)
        {
            int random = UnityEngine.Random.Range(0, 100);
            RaycastHit raycastHit;

            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out raycastHit, 300f))
            {
                firePosition.LookAt(raycastHit.point);
                if (raycastHit.collider.tag == "Metal")
                {
                    Instantiate(bulletHole, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
                }
                else if(raycastHit.collider.tag == "Enemy")
                {
                    if(critChance > random)
                    {
                        raycastHit.collider.GetComponent<EnemyHitBox>().TakeDamage((int)(baseGunDamage * ((float)critDamage / 100)));
                        Instantiate(robotHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal), raycastHit.transform);
                    }
                    else
                    {
                        raycastHit.collider.GetComponent<EnemyHitBox>().TakeDamage(baseGunDamage);
                        Instantiate(robotHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal), raycastHit.transform);
                    }
                }
                else if (raycastHit.collider.tag == "EnemyHead")
                {
                    if (critChance > random)
                    {
                        raycastHit.collider.GetComponent<EnemyHitBox>().TakeDamage((int)(baseGunDamage * ((float)critDamage / 100) * 3));
                        Instantiate(robotHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal), raycastHit.transform);
                    }
                    else
                    {
                        raycastHit.collider.GetComponent<EnemyHitBox>().TakeDamage(baseGunDamage * 3);
                        Instantiate(robotHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal), raycastHit.transform);
                    }
                }
            }
            else
            {
                firePosition.LookAt(fpsCamera.transform.position, (fpsCamera.transform.position * 50f));
            }
            recoilScript.RecoilFire();
            visualRecoilScript.RecoilFire();
            Instantiate(muzzleFlash, firePosition.position, firePosition.rotation, firePosition);
            bulletsAvailable--;
            AmmoUI.text = string.Format(bulletsAvailable + "/" + totalBullets);
            if (gunType == GunTypes.Pistol)
                shoot = false;
            if (bulletsAvailable == 0)
            {
                canReload = false;
                StartCoroutine(ReloadRoutine());
            }
            yield return new WaitForSecondsRealtime(1/fireRate);
        }
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSecondsRealtime(reloadTime);
        if(magazineSize <= totalBullets)
        {
            totalBullets -= magazineSize;
            bulletsAvailable = magazineSize;
            canReload = true;
        }
        else
        {
            bulletsAvailable = totalBullets;
            totalBullets = 0;
            canReload = false;
        }
        isReloading = false;
        AmmoUI.text = string.Format(bulletsAvailable + "/" + totalBullets);
    }

    public void AddMasteryDamage()
    {
        baseGunDamage += (int)((float)baseGunDamage * (15 * (float)gunMasteryVariable / 100));
    }

    public void IncreaseGunBaseDamage()
    {
        gunDamageLevel += 1;
        baseGunDamage = gunDamageArray[gunDamageLevel];
        AddMasteryDamage();
    }

    public void IncreaseGunMagazine()
    {
        gunMagazineSizeLevel += 1;
        magazineSize = gunMagazineSizeArray[gunMagazineSizeLevel];
    }

    public void IncreaseReloadSpeed()
    {
        gunReloadSpeedLevel += 1;
        reloadTime = gunReloadSpeedArray[gunReloadSpeedLevel];
    }

    public void IncreaseCritChance()
    {
        critChance += 5;
    }
    public void IncreaseCritDamage()
    {
        critDamage += 20;
    }
}
