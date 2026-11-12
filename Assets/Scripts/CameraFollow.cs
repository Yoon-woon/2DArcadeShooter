using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Target yang akan diikuti (masukkan objek Player)
    [SerializeField] private float smoothSpeed = 5f; // Kecepatan kehalusan pergerakan kamera
    [SerializeField] private Vector3 offset; // Jarak posisi kamera dari player (misal: Z = -10 supaya tidak menempel di player)

    void LateUpdate()
    {
        if (target != null)
        {
            // Tentukan posisi tujuan kamera berdasarkan posisi player ditambah offset
            Vector3 targetPosition = target.position + offset;

            // Geser kamera secara mulus (smooth) menuju posisi target menggunakan Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}