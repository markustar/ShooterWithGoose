using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool ThisIsEnemy;
    private bool ThisIsBox;
    private float Health = 100f;
    private void Start() {
        Health = 100f;
        if(this.gameObject.CompareTag("Enemy"))
        {
            ThisIsEnemy = true;
            ThisIsBox = false;
        }
        if(this.gameObject.CompareTag("Box"))
        {
            ThisIsEnemy = false;
            ThisIsBox = true;
        }
    }

    private void Update() {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage() 
    {
        if(ThisIsEnemy)
        {
            Health -= 20f;
        }
        if(ThisIsBox)
        {
            Destroy(gameObject);
        }
        
    }
}
