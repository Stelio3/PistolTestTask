using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour, ITarget
{
    public bool Ignore => true;

    public void TakeDamage(int amount)
    {

    }
}
