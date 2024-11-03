using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryItem : MonoBehaviour
{
    public float moveSpeed;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IngameUI.instance.ScoreUpdate(100);
        Destroy(gameObject);
    }
    private System.Collections.IEnumerator MoveCherry()
    {

      
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

   
        Vector3 targetPosition;

   
        if (transform.position.x < 0)
        {
            targetPosition = new Vector3(Camera.main.transform.position.x + cameraWidth / 2 + 1f,
                                          transform.position.y,
                                          0);
        }
        else 
        {
            targetPosition = new Vector3(Camera.main.transform.position.x - cameraWidth / 2 - 1f,
                                          transform.position.y,
                                          0);
        }

        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;

        while (Mathf.Abs(transform.position.x - targetPosition.x) > 0.1f)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1)
            {
                break;
            }

            yield return null;
        }

        Destroy(gameObject);
    }

    public void SetMoveCherry()
    {
        StartCoroutine(MoveCherry());
    }
}



