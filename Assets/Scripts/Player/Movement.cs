using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    #region Fields
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D playerRb;
    private Vector2 direction;
    private float speedInfo;
    #endregion

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void OnMovement(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        ForwardMovement();
        Rotation();
        OffBorderTeleport();
        EventManager.SendPlayerTransformAndSpeed(gameObject.transform, speedInfo);
    }
    private void ForwardMovement()
    {
        if (direction.y == 1)
        {
            playerRb.AddForce(speed * transform.up);
        }
        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
        speedInfo = Mathf.Round(playerRb.velocity.magnitude);
    }
    private void Rotation()
    {
        if (direction.x != 0)
        {
            playerRb.AddTorque(-direction.x * rotationSpeed);
        }
    }
    private void OffBorderTeleport()
    {
        if (transform.position.y >= Borders.verticalBorder)
        {
            transform.position = new Vector2(transform.position.x, -Borders.verticalBorder);
        }
        else if (transform.position.y <= -Borders.verticalBorder)
        {
            transform.position = new Vector2(transform.position.x, Borders.verticalBorder);
        }
        else if (transform.position.x >= Borders.horizontalBorder)
        {
            transform.position = new Vector2(-Borders.horizontalBorder, transform.position.y);
        }
        else if (transform.position.x <= -Borders.horizontalBorder)
        {
            transform.position = new Vector2(Borders.horizontalBorder, transform.position.y);
        }

    }
}
