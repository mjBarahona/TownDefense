using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{
    [SerializeField]
    private float TimeBetweenEachSpawn = 0.5f;
    [SerializeField]
    private List<Transform> _PositionsToRespawn;

    private void OnEnable()
    {
        GameManager.OnSpawn += Respawn;
    }

    public void Respawn(int amount, GenericObjectPool<BaseEnemy> pool)
    {
        StartCoroutine(RespawnAsinc(amount,pool));
       
        
    }

    IEnumerator RespawnAsinc(int amount, GenericObjectPool<BaseEnemy> pool)
    {
        int i = 0;
        while (i < amount)
        {
            BaseEnemy enemy = pool.Get();
            int respawn = UnityEngine.Random.Range(0, _PositionsToRespawn.Count);
            enemy.transform.position = _PositionsToRespawn[respawn].position;
            enemy.gameObject.SetActive(true);   //Reset stats when is activated
            yield return new WaitForSeconds(TimeBetweenEachSpawn);
            ++i;
        }
    }
}
