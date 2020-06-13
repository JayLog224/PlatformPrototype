using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public Transform firepoint;

    public Transform target;


    public float shootingRate;
    public float shootingCooldown = 0;

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            shootingCooldown += Time.deltaTime;

            if (shootingCooldown >= shootingRate)
            {
                Shoot();
                shootingCooldown = 0;
            }

        }
    }

    void Shoot()
    {
        Vector2 direction = firepoint.transform.position - target.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Instantiate(bulletPrefab, firepoint.transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }
}
