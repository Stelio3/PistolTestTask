using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour, ITarget
{
    public bool Ignore => false;

    public void TakeDamage(int amount)
    {
        
    }
}
