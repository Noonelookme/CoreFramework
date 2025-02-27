using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NewBehaviourScript: MonoBehaviour, IDamageble
{
    Rigidbody2D rb;
    Collider2D physicsCollider;

  
   private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
   

 
    public void OnHit(int damage, Vector2 knockback)
    {
        rb.AddForce(knockback);
    }

    
   
}
