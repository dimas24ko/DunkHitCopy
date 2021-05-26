using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ : MonoBehaviour
{
    public GameObject TargetObj, basketR, Gameplayer;
    private Mover _actionTarget;
    private Gameplay actionTarget;
    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<Mover>();
        actionTarget = Gameplayer.GetComponent<Gameplay>();
        basketR.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            basketR.gameObject.SetActive(false);
            _actionTarget.ChangeDirection();
            _actionTarget.GenerateBasketL();
            actionTarget.ResetTimer();
            Gameplay.score++;
        }

    }
}
