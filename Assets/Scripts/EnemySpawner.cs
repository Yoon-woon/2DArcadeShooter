using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab; // Cetakan musuh yang akan dimunculkan
    [SerializeField] private float spawnInterval = 2f; // Jangka waktu spawn (detik)
    [SerializeField] private float spawnRangeX = 8f;   // Batas area kiri-kanan tempat munculnya musuh

    private float timer = 0f;

    void Update()
    {
        // Menghitung waktu mundur setiap detiknya
        timer += Time.deltaTime;

        // Jika waktu sudah mencapai interval, munculkan musuh
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset timer dari awal
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Menentukan posisi acak di sumbu X bagian atas layar
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

            // Memunculkan musuh (Instantiate) ke dalam game
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
