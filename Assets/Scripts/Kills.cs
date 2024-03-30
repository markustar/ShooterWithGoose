using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    public Text KillsText;
    public int KillsInt;

    private void Start() {
        KillsInt = 0;
    }

    private void Update() {
        KillsText.text = KillsInt.ToString();
    }
}
