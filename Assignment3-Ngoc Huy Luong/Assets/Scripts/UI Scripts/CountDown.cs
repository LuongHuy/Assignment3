using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI goText;
    public float countdownTime = 3f;
  
    void Start()
    {
        StartCoroutine(StartCountDown()); 
    }

    private IEnumerator StartCountDown()
    {
        goText.gameObject.SetActive(false);
        for (int i = 3; i > 0; i--) 
        {
            countdownText.text = i.ToString();
            countdownText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        countdownText.gameObject.SetActive(false);
        goText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        goText.gameObject.SetActive(false);
    }
 
    void Update()
    {
        
    }
}
