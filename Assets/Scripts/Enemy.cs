using UnityEngine;

public class Enemy : Entity
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed = 3f;
    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();
        // Mencari posisi player otomatis di scene berdasarkan tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Musuh bergerak otomatis mendekati posisi player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    // LO2: Deteksi Tabrakan dengan Player atau Peluru
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Jika menabrak player, kurangi HP player
            Entity playerEntity = collision.GetComponent<Entity>();
            if (playerEntity != null)
            {
                playerEntity.TakeDamage(10f);
            }
            Destroy(gameObject); // Musuh hancur saat menabrak
        }
    }
}