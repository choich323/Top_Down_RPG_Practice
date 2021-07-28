using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Move value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check button down & up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check horizontal move
        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
    }

    void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;    
    }
}
