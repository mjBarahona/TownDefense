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
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && OnClick != null) OnClick(hit.point);
        }
    }
}
