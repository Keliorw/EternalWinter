using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class EnemySpawner : MonoBehaviour
{
    
    [Header("Инкрементор")]
    public float Incrimentor;
    [Header("Уровень")]
    public float Level;
    public GameObject WaveText;
    [Header("Сложность")]
    public float Difficult;
    [Header("Время когда мобы начинаю спавниться")]
    public float StartTime;
    public float SpawnInterval;
    public float Spawn;
    [Header("Стартовое кол-во мобов, которые спавняться")]
    public float Amount;

    [Header("Минимальное здоровье для мобов")]
    public float HealthBasicSnowman;
    public float HealthCarrotSnowman;
    public float HealthBucketSnowman;

    [Header("Минимальный урон для мобов")]
    public float DamageBasicSnowman;
    public float DamageCarrotSnowman;
    public float DamageBucketSnowman;

    [Header("Префабы всех мобов")]
    public List<GameObject> EnemyPrefabs;

    [Header("Лист спавна всех мобов")]
    public List<Enemy> enemyes;


    private float SpawnCount;
    private bool SpawnAll;

    void Start()
    {
        Amount = Amount*Mathf.Pow(Incrimentor, Level-1);
        AddEnemy((int)Mathf.Round(Amount), 10.0f);
    }

    void Update()
    {
        WaveText.GetComponent<Text>().text = "ур. "+Level.ToString()+" - "+SpawnCount.ToString();
    }

    private void FixedUpdate()
    {
        if(Level >= 5 && Level < 15)
        {
            Difficult = 2;
        } 
        else if(Level >= 15)
        {
            Difficult = 3;
        }
        if(SpawnAll && Time.time >= Spawn)
        {
            Spawn = Time.time+SpawnInterval;
            if(SpawnCount < 3)
            {
                if(Amount > 30){
                    Amount = 5;
                }
                Amount *= Mathf.Pow(Incrimentor, Level-1);
                if(Amount > 40){
                    Amount = 30;
                }
                AddEnemy((int)Mathf.Round(Amount), 10.0f);
                SpawnAll = false;
            }
            else 
            {
                Spawn = Time.time+SpawnInterval;
                Level++;
                if(Amount > 50){
                    Amount = 50;
                }
                Amount *= Mathf.Pow(Incrimentor, Level);
                AddEnemy((int)Mathf.Round(Amount), 10.0f);
                SpawnCount = 1;
                SpawnAll = false;
            }
            
        }
        int spawn = 0;
        foreach(Enemy enemy in enemyes)
        {
            if(enemy != null && enemy.isSpawned == false && enemy.spawnTime <= Time.time)
            {
                if(enemy.RandomSpawner)
                {
                    enemy.Spawner = Random.Range(0, transform.childCount);
                }
                GameObject enemyInstance = Instantiate(EnemyPrefabs[(int)enemy.enemyType], transform.GetChild(enemy.Spawner).transform);
                if((int)enemy.enemyType == 0)
                {
                    enemyInstance.transform.GetComponent<EnemyController>().Health = HealthBasicSnowman*Mathf.Pow(Incrimentor, Level-1);
                    enemyInstance.transform.GetComponent<EnemyController>().DamageValue = DamageBasicSnowman*Mathf.Pow(Incrimentor, Level-1);
                }
                if((int)enemy.enemyType == 1)
                {
                    enemyInstance.transform.GetComponent<EnemyController>().Health = HealthCarrotSnowman*Mathf.Pow(Incrimentor, Level-1);
                    enemyInstance.transform.GetComponent<EnemyController>().DamageValue = DamageCarrotSnowman*Mathf.Pow(Incrimentor, Level-1);
                }
                if((int)enemy.enemyType == 2)
                {
                    enemyInstance.transform.GetComponent<EnemyController>().Health = HealthBucketSnowman*Mathf.Pow(Incrimentor, Level-1);
                    enemyInstance.transform.GetComponent<EnemyController>().DamageValue = DamageBucketSnowman*Mathf.Pow(Incrimentor, Level-1);
                }
                transform.GetChild(enemy.Spawner).GetComponent<SpawnPoint>().enemies.Add(enemyInstance);
                enemy.isSpawned = true;
            }
            if(enemy.isSpawned == false)
            {
                spawn++;
            }
        }
        if(spawn == 0 && !SpawnAll)
        {
            SpawnAll = true;
            HealthBasicSnowman = HealthBasicSnowman*Mathf.Pow(Incrimentor, Level-1);
            DamageBasicSnowman = DamageBasicSnowman*Mathf.Pow(Incrimentor, Level-1);
            HealthCarrotSnowman = HealthCarrotSnowman*Mathf.Pow(Incrimentor, Level-1);
            DamageCarrotSnowman = DamageCarrotSnowman*Mathf.Pow(Incrimentor, Level-1);
            HealthBucketSnowman = HealthBucketSnowman*Mathf.Pow(Incrimentor, Level-1);
            DamageBucketSnowman = DamageBucketSnowman*Mathf.Pow(Incrimentor, Level-1);
        }
    }

    void AddEnemy(int Amount, float MaxAddTimeSpawn)
    {
        enemyes.RemoveAll(e => e.isSpawned == true);
        EnemyType TypeEnemy = EnemyType.Snowman_Basic;
        int Temp;
        for(int i = 0; i < Amount; i++)
        {
            switch(Difficult)
            {
                case 1:
                    TypeEnemy = EnemyType.Snowman_Basic;
                    break;
                case 2:
                    Temp = Random.Range(0, 2);
                    Debug.Log(Temp);
                    if(Temp == 0)
                    {
                        TypeEnemy = EnemyType.Snowman_Basic;
                    }
                    else
                    {
                        TypeEnemy = EnemyType.Snowman_Carrot;
                    }
                    break;
                case 3:
                    Temp = Random.Range(0, 4);
                    switch(Temp){
                        case 0:
                            TypeEnemy = EnemyType.Snowman_Basic;
                            break;
                        case 1:
                            TypeEnemy = EnemyType.Snowman_Carrot;
                            break;
                        case 2:
                            TypeEnemy = EnemyType.Snowman_Bucket;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            enemyes.Add(new Enemy() {spawnTime = Time.time+StartTime+Random.Range(0.0f, MaxAddTimeSpawn), enemyType = TypeEnemy, Spawner = 0, RandomSpawner = true, isSpawned = false});
        }
        SpawnCount++;
    }
}


