using System;
using TMPro;
using UnityEngine;

public class FloorDistance : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    [SerializeField] private TextMeshProUGUI floorDistanceText;

    private void Update()
    {   
        Vector3 distance = floor.transform.position - this.transform.position;
        floorDistanceText.text = $"Distance: {distance.magnitude}";
    }
}
