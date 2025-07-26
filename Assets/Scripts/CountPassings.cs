using System;
using TMPro;
using UnityEngine;

public class CountPassings : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countPassingsText;

    private int countPassings;

    public void OnTriggerEnter(Collider other)
    {
        countPassings += 1;
        countPassingsText.text = $"Passings: {countPassings}";
    }
}
