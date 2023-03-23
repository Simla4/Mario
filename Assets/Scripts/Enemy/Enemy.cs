using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawn, IDespawn
{
    #region Variables

    [SerializeField] private EnemyData enemyData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Pool<Enemy> enemyPool;

    #endregion

    #region Callbacks

    private void Start()
    {
        enemyPool = PoolManager.Instance.enemyPool;
    }

    #endregion

    #region OtherMethods

    public void OnSpawn()
    {
        spriteRenderer.sprite = enemyData.enemySprite;
        gameObject.SetActive(true);
    }

    public void OnDespawn()
    {
        StartCoroutine(EnemyDeadRoutune());
    }

    private IEnumerator EnemyDeadRoutune()
    {
        spriteRenderer.sprite = enemyData.enemyDeadSprite;

        yield return new WaitForSeconds(0.5f);
        
    }

    #endregion

    
}
