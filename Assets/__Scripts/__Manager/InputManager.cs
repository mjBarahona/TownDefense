using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    
    public static Action<Vector3> OnClick;

    private void Update()
    {
        // To make a basic attack
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("Floor");
            if (Physics.Raycast(ray, out hit, 200f, mask) && OnClick != null) OnClick(hit.point);
        }

        //Test in scene of pooling enemies // working
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var enemy = EnemyPool.Instance.Get();
        //    enemy.transform.position = new Vector3( 0f,0f,0f );
        //    enemy.gameObject.SetActive(true);
        //}
        //To test in scene the spawn of hordes with different respawns
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.NextHorde();
        }
    }
}
