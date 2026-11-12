using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Kecepatan terbang peluru
    [SerializeField] private float lifetime = 3f; // Waktu peluru hancur otomatis jika tidak kena apa-apa

    void Start()
    {
        // Hancurkan peluru otomatis setelah beberapa detik agar tidak memenuhi memori
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Membuat peluru bergerak lurus ke atas
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika peluru menengai musuh
        if (collision.CompareTag("Enemy"))
        {
            // Hancurkan musuhnya (atau kurangi HP musuh jika pakai script Entity)
            Destroy(collision.gameObject);

            // Hancurkan pelurunya juga
            Destroy(gameObject);
        }
    }
}