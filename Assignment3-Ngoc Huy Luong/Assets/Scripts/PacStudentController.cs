using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PacStudentController : MonoBehaviour
{
   

    private int[] validMovementValues = { 0, 5,6 };
    public float moveSpeed = 1f;
    private Vector3 targetPosition;
    private int currentX;
    private int currentY;
    private GameObject[,] tileBase;
    private KeyCode lastInput, currentInput;

    private AudioSource audioSource;
    private float soundInterval = 2f;
    private Coroutine soundCoroutine;

    public GameObject particlePrefab;
    private GameObject particleInstance;

    private bool isMove;

    public GameObject GetTileAtMapPosition(int mapX, int mapY)
    {

        if (mapX >= 0 && mapX < LevelGenerator.instance.fullMap.GetLength(1) && mapY >= 0 && mapY < LevelGenerator.instance.fullMap.GetLength(0))
        {

            return tileBase[mapY, mapX]; 
        }

        return null;
    }

    void Start()
    {
        tileBase = LevelGenerator.instance.tileBase;
        RestartPosition();
        audioSource = GetComponent<AudioSource>();

    }
    public void RestartPosition()
    {
        currentX = 1;
        currentY = 1;
        transform.position = GetTileAtMapPosition(currentX, currentY).transform.position;
        targetPosition = transform.position;
        currentInput = KeyCode.None;
    }
    void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentInput = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentInput = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentInput = KeyCode.S;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentInput = KeyCode.D;
        }
        if (CheckMoveDirection())
        {
            lastInput = currentInput;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            if (currentX == 0 && currentY == 14)
            {
                currentX = 27;               
            }
            else if (currentX == 27 && currentY == 14)
            {
                currentX = 0;              
            }
            transform.position = GetTileAtMapPosition(currentX, currentY).transform.position;
            MoveInLastDirection();
        }
    }

    private void MoveInLastDirection()
    {
        int moveX = 0;
        int moveY = 0;

        switch (lastInput)
        {
            case KeyCode.W:
                moveY = -1; 
                break;
            case KeyCode.A:
                moveX = -1; 
                break;
            case KeyCode.S:
                moveY = 1; 
                break;
            case KeyCode.D:
                moveX = 1; 
                break;
        }

            MovePlayer(moveX, moveY);
        if (particleInstance == null)
        {
            particleInstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            particleInstance.transform.parent = transform;
        }
    }

    private void MovePlayer(int moveX, int moveY)
    {
        int newX = currentX + moveX;
        int newY = currentY + moveY;

        if (newX >= 0 && newX < LevelGenerator.instance.fullMap.GetLength(1) && newY >= 0 && newY < LevelGenerator.instance.fullMap.GetLength(0))
        {

            if (IsValidMove(LevelGenerator.instance.fullMap[newY, newX]))
            {
                currentX = newX;
                currentY = newY;

                targetPosition = GetTileAtMapPosition(currentX, currentY).transform.position;
                
                lastInput = currentInput;

                if(soundCoroutine == null)
                {
                    soundCoroutine = StartCoroutine(PlaySound());
                }
                isMove = true;
            }
            if (!isMove)
            {
                if(soundCoroutine != null)
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
    }

    private bool CheckMoveDirection()
    {
        int moveX = 0;
        int moveY = 0;

        switch (currentInput)
        {
            case KeyCode.W:
                moveY = -1;
                break;
            case KeyCode.A:
                moveX = -1;
                break;
            case KeyCode.S:
                moveY = 1;
                break;
            case KeyCode.D:
                moveX = 1;
                break;
        }
        int newX = currentX + moveX;
        int newY = currentY + moveY;

        if (newX >= 0 && newX < LevelGenerator.instance.fullMap.GetLength(1) && newY >= 0 && newY < LevelGenerator.instance.fullMap.GetLength(0))
        {

            if (IsValidMove(LevelGenerator.instance.fullMap[newY, newX]))
            {
               return true;
            }
        }
        return false;
    }
    private bool IsValidMove(int tileValue)
    {

        foreach (int validValue in validMovementValues)
        {
            if (tileValue == validValue)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator PlaySound()
    {
        while (isMove)
        {
            audioSource.Play();
            yield return new WaitForSeconds(soundInterval);
        }
    }
}
