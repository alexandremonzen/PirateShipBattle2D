using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected TeamSide _teamSide;
    protected int _actualHealth;

    [SerializeField] protected Image _healthBar;

    [Header("Sprites")]
    [SerializeField] protected SpriteRenderer _actualHullLargeSprite;
    [SerializeField] protected SpriteRenderer _actualSailLargeSprite;
    [SerializeField] protected SpriteRenderer _actualSailSmallSprite;

    [Header("Sprites Change")]
    [SerializeField] protected Sprite[] _hullLargeSprites;
    [SerializeField] protected Sprite[] _sailLargeSprites;
    [SerializeField] protected Sprite[] _sailSmallSprites;

    [SerializeField] protected string _pathShipExplosion;
    
    public TeamSide teamSide { get => _teamSide; }

    protected void Awake()
    {
        _actualHealth = _maxHealth;
        UpdateSpriteVisual();
    }

    protected void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        _actualHealth = _maxHealth;
        UpdateSpriteVisual();
        UpdateHealthBarUI();
    }

    public void TakeDamage(int damage)
    {
        _actualHealth += damage;
        UpdateHealthBarUI();

        if (_actualHealth <= 0)
        {
            Die();
        }
        else
        {
            UpdateSpriteVisual();
        }
        FMODUnity.RuntimeManager.PlayOneShot(_pathShipExplosion, this.transform.position);
    }

    protected virtual void Die()
    {
        GameObject shipExplosionPrefab = ObjectPooler.SharedInstance.GetPooledShipExplosion();
        shipExplosionPrefab.transform.position = transform.position;
        shipExplosionPrefab.SetActive(true);
        gameObject.SetActive(false);
    }

    protected void UpdateHealthBarUI()
    {
        _healthBar.fillAmount = _actualHealth / (float)_maxHealth;
    }

    protected void UpdateSpriteVisual()
    {
        int setSprites = 0;

        switch(_actualHealth)
        {
            case int n when n > 49 && n < 100:
                setSprites = 1;
                break;

            case int n when n > 0 && n <= 49:
                setSprites = 2;
                break;

            default:
                break;
        }

        for(int i = 0; i < _hullLargeSprites.Length; i++)
        {
            _actualHullLargeSprite.sprite = _hullLargeSprites[setSprites];
            _actualSailLargeSprite.sprite = _sailLargeSprites[setSprites];
            _actualSailSmallSprite.sprite = _sailSmallSprites[setSprites];
        }
    }
}
