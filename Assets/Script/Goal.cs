using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject TargetObj, basketL, Gameplayer;
    private Mover _actionTarget;
    private Gameplay actionTarget;
    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<Mover>();
        actionTarget = Gameplayer.GetComponent<Gameplay>();
    }


    
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ball")
        {
            basketL.gameObject.SetActive(false);
            _actionTarget.ChangeDirection();
            _actionTarget.GenerateBasketR();
            actionTarget.ResetTimer();
            Gameplay.score++;
        }
    }
}
