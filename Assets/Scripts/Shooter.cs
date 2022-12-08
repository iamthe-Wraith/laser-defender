using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool isUsingAI;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] float minimumFireRate = 0.2f;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    void Start()
    {
        if (isUsingAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    float GetFireRate()
    {
        float randomFireRate = Random.Range(
            baseFireRate - fireRateVariance,
            baseFireRate + fireRateVariance
        );

        return Mathf.Clamp(randomFireRate, minimumFireRate, float.MaxValue);
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject projectile = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.identity
            );

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(projectile, projectileLifetime);

            yield return new WaitForSeconds(GetFireRate());
        }
    }
}
