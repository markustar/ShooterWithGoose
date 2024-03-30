using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float distance = 100f;
    public LayerMask EnemyLayer;

    [SerializeField] private Camera _camera;
    public TrailRenderer trailRenderer;
    public GameObject bulletMark;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        


        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, distance))
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
