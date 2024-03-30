using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Panel;
    public Slider HealthBar;
    public float HealthInt = 100f;

    private void Start() {
        Panel.SetActive(false);
        Cursor.visible = false;
    }

    private void Update() {
        HealthBar.value = HealthInt;
        if(HealthInt <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
        if(HealthInt > 100)
        {
            HealthInt = 100f;
        }
    }

    public void PlayerTakeDamage()
    {
        HealthInt -= 15f;
    }

}
