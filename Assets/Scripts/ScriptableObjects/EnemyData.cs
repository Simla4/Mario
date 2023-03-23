using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
    public Sprite enemyDeadSprite;
    public float argoRange;
    public float speed;
}
