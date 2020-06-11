using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform respawnPoint;
    public Animator animator;

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