using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SpriteMovement : MonoBehaviour
{

    //public Transform Sprite;

    private Transform spriteBody, spriteFalloff;
    private float minMovement = 0, maxMovement = 20;
    private bool goingRight;
        
    private Vector2 thisVelocity = Vector2.zero;
    [Range(0, .3f)] private float moveSmooth = 0.5f;

    private void Awake()
    {
        spriteBody    = transform.GetChild(0).gameObject.transform;
        spriteFalloff = transform.GetChild(1).gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (spriteBody.position.x )
        //for (int x = 0, x >= 20, x++)
        //spriteBody.position.x = spr;
        Vector2 falloffTarget = new Vector2(spriteBody.position.x, 
                                            spriteBody.position.y);
        spriteFalloff.position = Vector2.SmoothDamp(spriteFalloff.position,
                                                falloffTarget, ref thisVelocity,
                                                moveSmooth);
    }
}
