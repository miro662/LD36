using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    Collider2D _collider2d;
    void Awake()
    {
        _collider2d = GetComponent<Collider2D>();
    }

    [Zenject.Inject]
    GameManager _manager;

    public LayerMask player;

    void Update()
    {
        //Try to "catch" player
        RaycastHit2D hit = Physics2D.BoxCast(_collider2d.bounds.center, _collider2d.bounds.size, 0, Vector2.zero, 0, player);
        if (hit.collider != null)
        {
            _manager.Death();
        }
    }
}
