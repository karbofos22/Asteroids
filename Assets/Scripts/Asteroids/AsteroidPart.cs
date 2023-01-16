using UnityEngine;

public class AsteroidPart : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private float lifeTime = 10f;

    private void Start()
    {
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
}
