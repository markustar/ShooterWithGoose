using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpawner : MonoBehaviour
{
    public GameObject imagePrefab; // Префаб картинки для создания
    public Text intOfImages; 
    public float infOfObject;

    private void Start() {
        imagePrefab.SetActive(false);
        infOfObject = 0f;
    }

    
    public void ShowImages()
    {
        imagePrefab.SetActive(true);
        infOfObject += 1;
        intOfImages.text = infOfObject.ToString();

    }
}
