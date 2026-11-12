using UnityEngine;
public class Player : Entity
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    protected override void Start()
    {
        base.Start(); // Memanggil fungsi Start dari parent (Entity)
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // LO2: Input Movement Dasar
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // LO2: Physics movement menggunakan Rigidbody2D
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Gunakan firePoint.rotation agar peluru menghadap ke arah yang sama dengan FirePoint
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    // Override fungsi Die dari Entity khusus Player (Polymorphism)
    protected override void GameOver()
    {
        base.GameOver();
        Debug.Log("Game Over!");
    }
}
