using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{
    private float timer;
    private bool isIdling;
    private Animator animator;
    private Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        defaultPosition = transform.position;
        timer = Random.Range(5f, 10f);
        ReturnToIdle();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = defaultPosition;
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            if (isIdling)
            {
                int action = Random.Range(0, 2);

                switch (action)
                {
                    case 0:
                        Eat();
                        break;
                    case 1:
                        Sleep();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ReturnToIdle();
            }

            timer = Random.Range(5f, 10f);
        }
    }

    void ReturnToIdle()
    {
        animator.SetBool("isEating", false);
        animator.SetBool("isSleeping", false);
        isIdling = true;
    }

    void Eat()
    {
        animator.SetBool("isEating", true);
        isIdling = false;

    }

    void Sleep()
    {
        animator.SetBool("isSleeping", true);
        isIdling = false;
    }
}
