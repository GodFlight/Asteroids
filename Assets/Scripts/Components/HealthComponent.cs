using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 1;
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        SetHealthToMax();
    }

    public void SetHealthToMax()
    {
        CurrentHealth = _maxHealth;
    }

    public void AddHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, _maxHealth);
    }

}
