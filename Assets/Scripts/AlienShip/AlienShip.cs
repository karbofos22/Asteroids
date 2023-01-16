using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AlienShip : MonoBehaviour
{
    private Rigidbody2D shipRb;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private float speedMod;
    [SerializeField] private float lifeTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody2D>();
        EventManager.OnPlayerTransformAndSpeedChange.AddListener(FollowPlayer);
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<LaserShot>())
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        EventManager.SendEnemyKilled();
    }
    private void FollowPlayer(Transform playerPos, float speed)
    {
        transform.up = playerPos.position - transform.position;
        shipRb.AddForce(speed * speedMod * transform.up);
    }
}
