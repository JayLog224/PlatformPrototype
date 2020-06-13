using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 1f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable hitObject = collision.gameObject.GetComponent<IDamageable>();
        hitObject.TakeDamage(damage, collision);
        Destroy(this.gameObject);
    }
}
