using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Enemy
{
    public float spawnTime;
    public EnemyType enemyType;
    public int Spawner;
    public bool RandomSpawner;
    public bool isSpawned;
}

public enum EnemyType
{
    Snowman_Basic,
    Snowman_Carrot,
    Snowman_Bucket

}
