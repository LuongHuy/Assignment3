using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float Speed = 3f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Vector3 direction;
    private string lastInput;

    private AudioSource audioSource;
    private float soundInterval = 1f;
    private Coroutine soundCoroutine;

    public GameObject particlePrefab;
    private GameObject particleInstance;
    void Start()
    {
        targetPosition = transform.position;
        lastInput = "";
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleInput();
        MovePacStudent();
        Debug.Log(lastInput);
        Debug.Log(soundCoroutine);
    }

    private void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = "W";
            direction = new Vector3(0, 1, 0);
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = "S";
            direction = new Vector3(0, -1, 0);
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = "A";
            direction = new Vector3(-1, 0, 0);
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = "D";
            direction = new Vector3(1, 0, 0);
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            lastInput = "L";           
            isMoving = false;
        }
        
    }

    private void UpdateTargetPosition()
    {
        targetPosition = transform.position + direction;
        isMoving = true;     
      
     
    }
    private void MovePacStudent()
    {
        if (isMoving)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);   

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                targetPosition += direction;
               
            }
            if (soundCoroutine == null)
            {
                soundCoroutine = StartCoroutine(PlaySound());
            }
            if (particleInstance == null) 
            { 
                particleInstance = Instantiate(particlePrefab,transform.position, Quaternion.identity);
                particleInstance.transform.parent = transform;
            }
        }
        else
        {
            if (soundCoroutine != null)
            {
                StopCoroutine(soundCoroutine);
                soundCoroutine = null;
                audioSource.Stop();
            }
            if (particleInstance != null)
            {
                Destroy(particleInstance);
                particleInstance = null;
            }
        }
    }

    private IEnumerator PlaySound()
    {
        while (isMoving)
        {
            audioSource.Play();
            yield return new WaitForSeconds(soundInterval);
        }    
    }
}
