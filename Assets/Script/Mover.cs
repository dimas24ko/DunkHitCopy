using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rb;
    private float x, y;
    private bool direction = false;
    private int controller = 0;
    public static int checkerAnim = 0;
    public GameObject basketL, basketR;
    void Start()
    {
        Screen.SetResolution(900, 500, false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Gameplay.endGame)
        {
            checkerAnim = 0;
            if (Input.GetKeyDown(KeyCode.Mouse0)|| Input.GetKeyDown(KeyCode.Space))
            {
                BallJump();
                
            }
        }
        else {
            if(controller == 0)
            {
                StartCoroutine(RandomJump());
            }
        }
        
        

        if(transform.position.x <= -9.4f)
        {
            transform.position += new Vector3(2*9.4f, 0, 0);
            
        }
        if (transform.position.x >= 9.4f)
        {
            transform.position += new Vector3(2 * -9.4f, 0, 0);
        }

    }

    public IEnumerator RandomJump()
    {
        while (Gameplay.endGame)
        {
            controller++;
            //float time = (float)(Random.Range(1.5f, 2f));
            float direct = 0f;
            Vector2 jjump = new Vector2(direct, 8f);
            rb.AddForce(jjump, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    public void Starter()
    {
        if (checkerAnim == 0)
        {
            StartCoroutine(RandomJump());
            checkerAnim++;
        }
        
    }
    void BallJump()
    {
        float direct;
        if (direction == true)
        {
            direct = 3f;
        }
        else direct = -3f;
        rb.velocity = Vector2.zero;
        Vector2 jjump = new Vector2(direct, 8f);
        
        rb.AddForce(jjump, ForceMode2D.Impulse);
    }

    public void ChangeDirection()
    {
        direction = !direction;
    }
    public void GenerateBasketL()
    {
        basketR.gameObject.SetActive(false);
        float x = (float)(Random.Range(-7f, -4f));
        float y = (float)(Random.Range(-3f, 2f));
        basketL.transform.position = new Vector3(x, y, 0);
        basketL.gameObject.SetActive(true);

    }
    public void GenerateBasketR()
    {
        basketL.gameObject.SetActive(false);
        float x = (float)(Random.Range(7.5f, 3f));
        float y = (float)(Random.Range(-3f, 2f));
        basketR.transform.position = new Vector3(x, y, 0);
        basketR.gameObject.SetActive(true);
    }

}
