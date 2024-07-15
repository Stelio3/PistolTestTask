using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    bool Ignore { get; }

    void TakeDamage(int amount);
}