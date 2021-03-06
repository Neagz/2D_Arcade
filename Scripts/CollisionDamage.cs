using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage = 10;
    public string collisionTag;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(collisionTag))
        {
            Health health = col.gameObject.GetComponent<Health>();
            health.TakeHit(damage);
            if (animator != null) 
                animator.SetTrigger("StartBiting");
        }
    }
}
