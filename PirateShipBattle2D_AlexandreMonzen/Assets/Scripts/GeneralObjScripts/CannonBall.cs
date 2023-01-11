using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CannonBall : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private TrailRenderer _trailRenderer;

    [SerializeField] private int _damage;
    [SerializeField] private TeamSide _teamSide;
    [SerializeField] private Vector2 _forceCannonBall;
    [SerializeField] private float _timeToDeactivate;

    public int damage { get => _damage; }
    public TeamSide teamSide { get => _teamSide; }
    public Vector2 forceCannonBall { set => _forceCannonBall = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = transform.GetChild(0).GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        ShootCannonBall();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Health health = col.GetComponent<Health>();

        if (health)
        {
            if (health.teamSide != _teamSide)
            {
                health.TakeDamage(_damage);
                ActiveExplosion();
            }
        }
    }

    private void ShootCannonBall()
    {
        _trailRenderer.Clear();
        _rigidbody.AddRelativeForce(new Vector2(_forceCannonBall.x, _forceCannonBall.y), ForceMode2D.Impulse);
    }

    public void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void ActiveExplosion()
    {
        GameObject explosionPrefab = ObjectPooler.SharedInstance.GetPooledCannonBallExplosion();
        explosionPrefab.transform.position = transform.position;
        explosionPrefab.SetActive(true);
        DeactivateGameObject();
    }
}
