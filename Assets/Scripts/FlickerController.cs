using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    private Animator animator;
    public float flickerChance = 0.2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void Start()
    {
        InvokeRepeating("FlickerChance", 1f, 2f);
    }

    private void FlickerChance()
    {
        float rand = Random.Range(0f, 1f);
        if (rand <= flickerChance)
        {
            animator.SetTrigger("Flicker");
        }   
    }
}
