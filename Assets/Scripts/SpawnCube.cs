using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public Transform spawnPoint;

    public void Start()
    {
        GameObject prefab = Resources.Load("RotatingCube") as GameObject;

        prefab.transform.position = spawnPoint.position;

        Instantiate(prefab);
    }
 }
