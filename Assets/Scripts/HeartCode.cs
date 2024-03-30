using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCode : MonoBehaviour
{
    public PlayerHealth HealPlayer;
    public ImageSpawner imageSpawner;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(HealPlayer.HealthInt != 100)
            {
                HealPlayer.HealthInt += 20;
                
            }
            else
            {
                imageSpawner.ShowImages();  
            }
            
            Destroy(this.gameObject);
        }

    }

}
