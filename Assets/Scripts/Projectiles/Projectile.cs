using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    [SerializeField] private float projectileSpeed = 100f;
    [SerializeField] private float lifeTime = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileRb.velocity = transform.up * projectileSpeed;
        Destroy(gameObject, lifeTime);
    }
}
