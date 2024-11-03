using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public CherryItem cherryPrefab;
    public float spawnInterval = 10f; 
    

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; 
        InvokeRepeating(nameof(SpawnCherry), 0f, spawnInterval); 
    }

    private void SpawnCherry()
    {
       
        Vector3 spawnPosition = GetRandomSpawnPosition();

        var cherry = Instantiate(cherryPrefab, spawnPosition, Quaternion.identity);
        cherry.SetMoveCherry();
    }

    private Vector3 GetRandomSpawnPosition()
    {

        // Get the camera's height and width based on its orthographic size
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Get the camera's position
        Vector3 cameraPosition = mainCamera.transform.position;

        // Choose a random side to spawn the cherry
        int side = Random.Range(0, 2);
        Vector3 spawnPosition;

        if (side == 0) // Left side
        {
            spawnPosition = new Vector3(cameraPosition.x - cameraWidth / 2 - 1f,
                                         cameraPosition.y + Random.Range(-cameraHeight / 2, cameraHeight / 2),
                                         cameraPosition.z);
        }
        else // Right side
        {
            spawnPosition = new Vector3(cameraPosition.x + cameraWidth / 2 + 1f,
                                         cameraPosition.y + Random.Range(-cameraHeight / 2, cameraHeight / 2),
                                         cameraPosition.z);
        }

        return spawnPosition;
    }
}
