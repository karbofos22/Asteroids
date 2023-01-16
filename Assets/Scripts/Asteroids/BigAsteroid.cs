using UnityEngine;

public class BigAsteroid : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject asteroidPart;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private float projectileSpeed = 100f;
    [SerializeField] private float lifeTime = 10f;

    private Collider2D[] inExplosionRadius = null;
    [SerializeField] private float multiExplosionForse = 35;
    [SerializeField] private float explosionRadius = 1f;

    private Rigidbody2D projectileRb;
    Vector2 spawnPos;
    #endregion
    void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        spawnPos = transform.position;
    }
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void FixedUpdate()
    {
        MoveDirection(-spawnPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
            AsteroidSplit();
            AsteroidSplit();
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<LaserShot>())
        {
            AsteroidSplit();
            AsteroidSplit();
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void Explosion()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D item in inExplosionRadius)
        {
            if (item.TryGetComponent<Rigidbody2D>(out Rigidbody2D itemRb))
            {
                Vector2 distance = item.transform.position - transform.position;
                if (distance.magnitude > 0)
                {
                    float expolosionForce = multiExplosionForse / distance.magnitude;
                    itemRb.AddForce(distance.normalized * expolosionForce);
                }
            }
        }
    }
    private void AsteroidSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Instantiate(asteroidPart, position, transform.rotation);
        Explosion();
    }
    private void MoveDirection(Vector2 direction)
    {
        projectileRb.AddForce(direction * projectileSpeed);
    }
}
