using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public Transform respawnPoint;
    public Animator animator;

    public float hitpoints = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            StartCoroutine(Die());
        }
    }

    void SetRespawnPosition()
    {
        transform.position = respawnPoint.transform.position;
    }

    public void TakeDamage(float damage, Collision2D collision)
    {
        hitpoints -= damage;
        if (hitpoints <=0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        animator.SetBool("HasDied", true);
        yield return new WaitForSeconds(0.4f);
        Respawn();
    }

    void Respawn()
    {
        animator.SetBool("HasDied", false);
        transform.position = respawnPoint.transform.position;
    }
}