using System;
using TMPro;
using UnityEngine;

public class CountBounces : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countBouncesText;

    private int countBounces;

    public void OnCollisionEnter(Collision other)
    {
        countBounces += 1;
        countBouncesText.text = $"Bounces: {countBounces}";
    }
}
