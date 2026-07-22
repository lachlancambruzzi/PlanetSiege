using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Fire Rate")]
    public float defaultFireRate = 0.5f;
    public float boostedFireRate = 0.2f;
    public float fireRate; // current fire rate

    private float nextFireTime;

    void Start()
    {
        fireRate = defaultFireRate;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void ActivateFireRateBoost(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(FireRateBoostCoroutine(duration));
    }

    private IEnumerator FireRateBoostCoroutine(float duration)
    {
        fireRate = boostedFireRate;
        yield return new WaitForSeconds(duration);
        fireRate = defaultFireRate;
    }
}