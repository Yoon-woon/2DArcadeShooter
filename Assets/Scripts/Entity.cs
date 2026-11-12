using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    [Header("Encapsulation")]
    [SerializeField] protected float MaxHealth = 100f;
    protected float CurrentHealth;
    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        Debug.Log(gameObject.name + " terkena damage. Sisa HP: " + CurrentHealth);

        if (CurrentHealth <= 0)
        {
            GameOver();
        }
    }

    protected virtual void GameOver()
    {
        Destroy(gameObject);
    }
}
