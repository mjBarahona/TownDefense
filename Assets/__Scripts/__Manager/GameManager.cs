using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesHordeInfo
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private int Id;
    [SerializeField]
    private int InitialAmountToSpawn = 20;
    [SerializeField]
    private int RisePerHorde = 10;
    [SerializeField]
    private GameObject EnemyPrefab;


    public int GetCurrentHordeAmount(int horde)
    {
        return horde * RisePerHorde + InitialAmountToSpawn;
    }
    public void SetId(int id) { Id = id; }
    public int GetId() { return Id; }
    public GameObject GetEnemyPrefab() { return EnemyPrefab; }

}

public class GameManager : Singleton<GameManager>
{
    [Header("Amount enemies for pools")]
    [SerializeField]
    private List<EnemiesHordeInfo> Enemies;
    private int _CurrentTotalEnemies;

    private int _horde { get; set; }
    private int _coins { get; set; }


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
            Enemies[i].SetId(i);
            _CurrentTotalEnemies += Enemies[i].GetCurrentHordeAmount(_horde);
            //PoolManager.Instance.SpawnEnemy(Enemies[i].GetId(), Enemies[i].GetCurrentHordeAmount(_horde));  // I have to think a bit more about this
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
        for (int i = 0; i < Enemies.Count; ++i) _CurrentTotalEnemies += Enemies[i].GetCurrentHordeAmount(_horde);
       

        // Update the UI
        // UiManager.Instance.ShowHorde(_horde)
        // 
    }


}
