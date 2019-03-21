using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;

    private float speedFactor = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput < 0)
        {
            Flip(true);
        }
        else if (horizontalInput > 0)
        {
            Flip(false);
        }
        _playerAnimation.SideWalk(horizontalInput);
        _rigid.velocity = new Vector2(horizontalInput * speedFactor, verticalInput * speedFactor);

    }

    void Flip(bool isHeadingLeft)
    {
        _spriteRenderer.flipX = !isHeadingLeft;
    }
}
