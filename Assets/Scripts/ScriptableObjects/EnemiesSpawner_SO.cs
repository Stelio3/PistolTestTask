using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesSpawner", menuName = "Enemies")]
[System.Serializable]
public class EnemiesSpawner_SO : ScriptableObject
{
    public SpawnProbability[] enemy;
}
[System.Serializable]
public class SpawnProbability
{
    public GameObject prefab;
    [Range(0f, 100f)] public float Chance = 100f;

    [HideInInspector] public double _weight;
}
