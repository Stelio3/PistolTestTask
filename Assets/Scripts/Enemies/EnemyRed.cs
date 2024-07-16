using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour, ITarget
{
    public bool Ignore => false;

    public void TakeDamage(int amount)
    {
        EnemySpawner.Instance.DestroyEnemy(gameObject);
    }
}
