/*using PlayerSpace;
using UnityEngine;

public class Enemy1 : EnemyAll
{
    [SerializeField] private int _lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject);
        {
            Player.Instance.GetDamage()
            _lives--;
            Debug.Log("У врага осталось " + _lives);
        }
        if (_lives < 1)
        {
            Die();
        }
    }
}
*/