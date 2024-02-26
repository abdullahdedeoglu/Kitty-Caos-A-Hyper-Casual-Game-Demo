using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform destination;
    public float radius = 10f;
    public Animator animator;
    public GameManager gameManager;
    private float remainingDistance;

    private void Update()
    {
        if(gameManager.gameStarted && remainingDistance <= 1.5f)
        {
            ChangeDestination();
        }
    }

    public void ChangeDestination()
    {

    }
}
