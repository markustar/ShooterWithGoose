using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

   public TrailRenderer trailRenderer;
   [SerializeField] private Camera _camera;
   public float range;

   public GameObject bulletMark;
   private void Update() {

        if (Input.GetButtonDown("Fire1") )
        {
            Fire();
        }    

   }

   void Fire()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            GameObject hitObject =  hit.transform.gameObject;
            Target target = hitObject.GetComponent<Target>();         
                        
            if (target) 
            {
                target.TakeDamage();
            }
            else 
            {
                Instantiate(bulletMark, hit.point, Quaternion.LookRotation(hit.normal));
                //CreateSphere(hit.point);
            }
        } 
    }

    void CreateSphere(Vector3 pos)
    {
        GameObject sphere =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        Destroy(sphere, 5f);
    }

    
}
