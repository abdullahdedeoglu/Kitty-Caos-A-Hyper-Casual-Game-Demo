using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField] private float explosionVelocity = 75f;
    [SerializeField] private float explosionRadius = 30f;

    [SerializeField] private GameObject particles;
    [SerializeField] private SetScore setScore;
    [SerializeField] private SetCoin setCoin;
    [SerializeField] private GameManager gm;
    [SerializeField] private EnemyCatAI enemy;

    public bool isAI;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isAI)
        {
            if (hit.gameObject.tag == "hittable" || hit.gameObject.tag == "hittedByAI")
            {
                hit.gameObject.tag = "hitted";
                Explosion(hit);
                setScore.AdjustScore();
                setCoin.AdjustCoin();
            }
        }

    }
    private void Explosion(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddExplosionForce(explosionVelocity, hit.transform.position + Vector3.back, explosionRadius);
        Instantiate(particles,hit.gameObject.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAI && gm.gameStarted)
        {
            if (other.gameObject.tag == "hittable")
            {
                other.gameObject.tag = "hittedByAI";
                Rigidbody rb_other = other.gameObject.GetComponent<Rigidbody>();
                if(other.gameObject.name != "Wall")
                {
                    rb_other.isKinematic = false;
                    rb_other.AddExplosionForce(explosionVelocity, other.transform.position + Vector3.back, explosionRadius);
                    Instantiate(particles, other.gameObject.transform.position, Quaternion.identity);
                }
                enemy.SetScore();
                if (!gm.gameEnded)
                    enemy.ChangeDestination();
            }
        }
    }
}
