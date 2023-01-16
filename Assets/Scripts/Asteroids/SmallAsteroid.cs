using System.Drawing;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    #region Fields
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float projectileSpeed = 100f;
    [SerializeField] private float lifeTime = 10f;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveDirection(-spawnPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() || collision.gameObject.GetComponent<LaserShot>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        EventManager.SendEnemyKilled();
    }
    private void MoveDirection(Vector2 direction)
    {
        projectileRb.AddForce(direction * projectileSpeed);
    }
}
