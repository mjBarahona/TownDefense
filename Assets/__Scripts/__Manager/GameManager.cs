using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesHordeInfo
{
    [SerializeField]
    private string _Name;
    [SerializeField]
    private int _InitialAmountToSpawn = 20;
    [SerializeField]
    private int _RisePerHorde = 10;
    [SerializeField]
    private GenericObjectPool<BaseEnemy> _EnemyRespawns;


    public int GetCurrentHordeAmount(int horde)
    {
        return horde * _RisePerHorde + _InitialAmountToSpawn;
    }

    public GenericObjectPool<BaseEnemy> GetPool()
    {
        return _EnemyRespawns;
    }
}

public class GameManager : Singleton<GameManager>
{
    [Header("Amount enemies for pools")]
    [SerializeField]
    private List<EnemiesHordeInfo> Enemies;
    private int _CurrentTotalEnemies;

    private int _horde { get; set; }
    private int _coins { get; set; }

    public static Action<int, GenericObjectPool<BaseEnemy>> OnSpawn;

    private void OnEnable()
    {
        BaseEnemy.OnDeath += KilledEnemy;
        BaseEnemy.OnEarnCoins += UpdateCoins;
    }

    public void InitGame()
    {
        _horde = 0;
        // UiManager.Instance.ShowHorde(_horde)
        // UiManager.Instance.UpdateCoins(_coins);
        for (int i = 0; i < Enemies.Count; ++i)
        {
            _CurrentTotalEnemies += Enemies[i].GetCurrentHordeAmount(_horde);
            //UiManager.Instance.ShowHorde(_horde)
            //CallToRespawnEnemies()
        }

    }

    public void UpdateCoins(int amount)
    {
        _coins += amount;
        // Update the UI
        // UiManager.Instance.UpdateCoins(_coins);
    }

    //Called when an enemy is killed to check if it is necessary to go to the next level.
    public void KilledEnemy()
    {
        --_CurrentTotalEnemies;
        if(_CurrentTotalEnemies == 0){
          NextHorde();
        }
    }

    public void NextHorde()
    {
        ++_horde;
        CallToRespawnEnemies();
        

        // Update the UI
        // UiManager.Instance.ShowHorde(_horde)
        // 
    }

    public void CallToRespawnEnemies()
    {
        for (int i = 0; i < Enemies.Count; ++i)
        {
            _CurrentTotalEnemies += Enemies[i].GetCurrentHordeAmount(_horde);
            if(OnSpawn != null) OnSpawn(Enemies[i].GetCurrentHordeAmount(_horde), Enemies[i].GetPool());
        }
            
    }

}
