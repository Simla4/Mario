using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public Pool<Enemy> enemyPool { get; } = new Pool<Enemy>();
    [SerializeField] private Enemy enemyPrefab;
    private void Awake()
    {
        enemyPool.Initialize(enemyPrefab);
    }
}
