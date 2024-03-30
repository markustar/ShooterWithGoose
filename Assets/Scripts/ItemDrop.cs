using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Kills KillInt;
    public GameObject ItemPrefab;
    public Transform ItemSpawner;

    private GameObject spawnedItem;

    private void OnDestroy()
    {
        KillInt.KillsInt += 1;
        if (ItemPrefab != null && ItemSpawner != null)
        {
            // Instantiate the item
            spawnedItem = Instantiate(ItemPrefab, ItemSpawner.position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }

    private void OnDisable()
    {
        // Destroy the spawned item when the GameObject is disabled or destroyed
        if (spawnedItem != null)
        {
            Destroy(spawnedItem);
        }
    }
}
