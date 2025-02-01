using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int collectibleCount;
    public int totalBone = 5;
    public TextMeshProUGUI count;

    private void Update()
    {
        count.text = "Bone Collected : " + collectibleCount.ToString();
    }


}
