using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public float shootsPerSecond;
    public int reloadSpeed;
    public Vector3 aimPosition;

    public float smooth;

    bool isReloading;
    bool isShooting;
    bool isAiming;
    int ammo;

    public ParticleSystem sideFlash;
    public ParticleSystem straightFlash1;
    public ParticleSystem straightFlash2;

    public TMP_Text ammoText;

    [SerializeField] private Camera _camera;
    public float range;

    public GameObject bulletMark;

    
    private void Start() {
        ammo = maxAmmo;
        ammoText.text = ammo + "/" + maxAmmo;
    }

    private void Update() {

        if (Input.GetButton("Fire1") && !isReloading && !isShooting)
        {
            if (ammo <= 0) return;

            ammo--;
            ammoText.text = ammo + "/" + maxAmmo;
            Fire();
            StartCoroutine(Shooting());
        }    

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        isAiming = Input.GetMouseButton(1) && !isReloading;
        transform.localPosition = Vector3.Lerp(transform.localPosition, 
            isAiming ? aimPosition : Vector3.zero, smooth * Time.deltaTime);
        
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 
            isAiming ? 40 : 60, smooth * Time.deltaTime);
        
        
        
         

    }

    void Fire()
    {
        sideFlash.Play();
        straightFlash1.Play();
        straightFlash2.Play();

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

    private IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        yield return new WaitForSeconds(3);
        ammo = maxAmmo;
        ammoText.text = ammo + "/" + maxAmmo;
        isReloading = false;
    }

    private IEnumerator Shooting()
    {
        isShooting = true;
        //Debug.Log(1 / shootsPerSecond);
        yield return new WaitForSeconds(1f / shootsPerSecond);
        isShooting = false;
    }


}
