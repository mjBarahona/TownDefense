using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesHordeInfo
{
    [SerializeField]
    private int InitialAmountToSpawn = 20;
    [SerializeField]
    private int RisePerHorde = 10;

    public int GetCurrentHordeAmount(int horde)
    {
        return horde * RisePerHorde + InitialAmountToSpawn;
    }
}

public class GameManager : Singleton<GameManager>
{
    [Header("Amount enemies for pools")]
    [SerializeField]
    private EnemiesHordeInfo Orcs;  // It should be a list in a future
    private int CurrentTotalEnemies;

    private int _horde { get; set; }
    private int _coins { get; set; }


    public void InitGame()
    {
        _horde = 0;
        // UiManager.Instance.ShowHorde(_horde)
        // UiManager.Instance.UpdateCoins(_coins);
        // PoolManager.Instance.SpawnEnemy<TypeEnemy>(Orcs.GetCurrentHordeAmount(_horde));  // I have to think a bit more about this
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
        --CurrentTotalEnemies;
        if(CurrentTotalEnemies == 0){
          NextHorde();
        }
    }

    public void NextHorde()
    {
        ++_horde;
        //for(uint i = 0; i < Enemies.count; ++i) CurrentTotalEnemies+= Enemies[i].GetCurrentHordeAmount(_horde)
        CurrentTotalEnemies += Orcs.GetCurrentHordeAmount(_horde);

        // Update the UI
        // UiManager.Instance.ShowHorde(_horde)
        // 
    }


}
