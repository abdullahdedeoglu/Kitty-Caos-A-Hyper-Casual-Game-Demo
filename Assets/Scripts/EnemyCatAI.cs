using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCatAI : MonoBehaviour
{
    public NavMeshAgent nma;
    public float radius = 10f;
    public Animator animator;
    public int score = 0;
    public GameManager gameManager;

    private void Update()
    {
        if (gameManager.gameStarted && !gameManager.gameEnded && nma.remainingDistance < 0.7f)
        {
            ChangeDestination();
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("EnemyScore", 0);
        nma.destination = RandomNavMeshLocation(radius);
        animator.SetBool("canMove", true);
        InvokeRepeating("ChangeDestination", Random.Range(8, 12), Random.Range(8, 12));
    }

    public Vector3 RandomNavMeshLocation(float radius)
    {
        float randomPositionX = Random.Range(-1.5f, 1.75f);
        float randomPositionZ = Random.Range(-4.85f, 4.1f);
        Debug.Log("Random Z Position: " + randomPositionZ);
        Vector3 randomDirection = new Vector3(randomPositionX, 0, randomPositionZ);
        return randomDirection;
    }

    public void SetScore()
    {
        score += 50;
        PlayerPrefs.SetInt("EnemyScore", score);
    }
    public void ChangeDestination()
    {
        nma.destination = RandomNavMeshLocation(radius);
    }
}
