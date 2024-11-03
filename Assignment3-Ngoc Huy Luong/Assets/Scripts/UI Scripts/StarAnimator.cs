using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimator : MonoBehaviour
{
    public RectTransform dotTransform;
    public Vector2[] destinations;
    public float lerpSpeed = 0.1f;

    private int currentDestinationIndex = 0;
    private Vector2 targetPosition;

  
    void Start()
    {
        if (destinations.Length > 0)
        {
            targetPosition = destinations[0];
        }
    }

 
    void Update()
    {
        dotTransform.anchoredPosition = Vector2.MoveTowards(dotTransform.anchoredPosition, targetPosition, lerpSpeed);

        if (Vector2.Distance(dotTransform.anchoredPosition, targetPosition) < 1f)
        {
            currentDestinationIndex = (currentDestinationIndex +1) % destinations.Length;
            targetPosition = destinations[currentDestinationIndex];
        }
    }
}
