using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private EnemyData enemyData;
    [SerializeField] private LayerMask layerMask;
    private Vector2 firstPos;
    private GameObject player;

    #endregion

    #region Callbacks

    private void Start()
    {
        firstPos = transform.position;
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    #endregion

    #region Other Methods

    private bool CanSeePlayer()
    {
        var argoRange = enemyData.argoRange;
        var origin = transform.position.x - argoRange;
        
        var hit = Physics2D.Raycast(new Vector2(origin, transform.position.y), Vector2.right, argoRange  * 2, layerMask);

        var isEnemySee = false;

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                isEnemySee = true;

                player = hit.collider.gameObject;
            }
        }
        else
        {
            isEnemySee = false;
        }

        return isEnemySee;
    }

    private void ChasePlayer()
    {
        var currentPos = transform.position;

        currentPos.x = Mathf.MoveTowards(currentPos.x, player.transform.position.x, Time.deltaTime * enemyData.speed);
        transform.position = new Vector3(currentPos.x, currentPos.y, 0);
    }

    private void StopChasingPlayer()
    {
        var currentPos = transform.position;
        
        currentPos.x = Mathf.MoveTowards(currentPos.x, firstPos.x, Time.deltaTime * enemyData.speed);
        transform.position = new Vector3(currentPos.x, currentPos.y, 0);
    }

    #endregion
}
