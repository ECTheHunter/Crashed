using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterModel : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float oksijen = 50f;
    [SerializeField]
    private float maxOksijen = 100f;
    [SerializeField]
    private float aclik = 100f;
    [SerializeField]
    private float maxAclik = 100f;
    [SerializeField]
    private float susuzluk = 100f;
    [SerializeField]
    private float maxSusuzluk = 100f;

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image oksijenBar;
    [SerializeField]
    private Image aclikBar;
    [SerializeField]
    private Image susuzlukBar;
    [SerializeField] PauseMenuScript pauseMenuScript;
    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            // You can add additional logic here if needed, like triggering events.
        }
    }
    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = Mathf.Max(0, value);
    }
    public float Oksijen
    {
        get => oksijen;
        set
        {
            oksijen = Mathf.Clamp(value, 0, maxOksijen);
            // You can add additional logic here if needed, like triggering events.
        }
    }
    public float MaxOksijen
    {
        get => maxOksijen;
        set => maxOksijen = Mathf.Max(0, value);
    }

    public float Aclik
    {
        get => aclik;
        set
        {
            aclik = Mathf.Clamp(value, 0, maxAclik);
            // You can add additional logic here if needed, like triggering events.
        }
    }
    public float MaxAclik
    {
        get => maxAclik;
        set => maxAclik = Mathf.Max(0, value);
    }

    public float Susuzluk
    {
        get => susuzluk;
        set
        {
            susuzluk = Mathf.Clamp(value, 0, maxSusuzluk);
            // You can add additional logic here if needed, like triggering events.
        }
    }
    public float MaxSusuzluk
    {
        get => maxSusuzluk;
        set => maxSusuzluk = Mathf.Max(0, value);
    }


    void Update()
    {
        if (!pauseMenuScript.IsPaused)
        {
            DecraseOksijen(0.03f);
            DecraseAclik(0.01f);
            DecraseSusuzluk(0.02f);
        }

    }
    public void DecraseHealth(float amount)
    {
        Health -= amount;
        UpdateHealthBar();
    }
    public void IncreaseHealth(float amount)
    {
        Health += amount;
        UpdateHealthBar();
    }
    public void DecraseOksijen(float amount)
    {
        Oksijen -= amount;
        UpdateOksijenBar();
    }
    public void IncreaseOksijen(float amount)
    {
        Oksijen += amount;
        UpdateOksijenBar();
    }
    public void DecraseAclik(float amount)
    {
        Aclik -= amount;
        UpdateAclikBar();
    }
    public void IncreaseAclik(float amount)
    {
        Aclik += amount;
        UpdateAclikBar();
    }
    public void DecraseSusuzluk(float amount)
    {
        if (Susuzluk - amount < 0)
        {
            Susuzluk = 0;
        }
        else
        {
            Susuzluk -= amount;
        }
        UpdateSusuzlukBar();
    }
    public void IncreaseSusuzluk(float amount)
    {
        if (Susuzluk + amount > MaxSusuzluk)
        {
            Susuzluk = MaxSusuzluk;
        }
        else
        {
            Susuzluk += amount;
        }

        UpdateSusuzlukBar();
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)Health / MaxHealth;
        }
    }
    private void UpdateOksijenBar()
    {
        if (oksijenBar != null)
        {
            oksijenBar.fillAmount = (float)Oksijen / MaxOksijen;
        }
    }
    private void UpdateAclikBar()
    {
        if (aclikBar != null)
        {
            aclikBar.fillAmount = (float)Aclik / MaxAclik;
        }
    }
    private void UpdateSusuzlukBar()
    {
        if (susuzlukBar != null)
        {
            susuzlukBar.fillAmount = (float)Susuzluk / MaxSusuzluk;
        }
    }


}
