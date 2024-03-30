using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gooseSpawner : MonoBehaviour
{
    public float timer;
    public GameObject GoosePrefab;
    public Transform PlaceToSpawn; // Change to Transform type
    public GameObject Player;

    void Update()
    {
        if (timer >= 5)
        {
            Instantiate(GoosePrefab, PlaceToSpawn.position, Quaternion.LookRotation(Player.transform.position - PlaceToSpawn.position));
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
