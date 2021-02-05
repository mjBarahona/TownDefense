using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    private void Start()
    {
        //It should be a event in the main character, and Fire should be called
        //when the animation of attack is finished with another event
        InputManager.OnClick += Fire;   
    }
 
    public void Fire(Vector3 target)
    {
        var shot = ShotPool.Instance.Get();
        shot.transform.position = transform.position;
        shot.SetOrientation(target);
        shot.gameObject.SetActive(true);

    }
}
