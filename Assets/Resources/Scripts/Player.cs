using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;

    private float speedFactor = 3.0f;

    //testing section
    private int count = 1;

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
        Flip(horizontalInput < 0);
        _rigid.velocity = new Vector2(horizontalInput * speedFactor, verticalInput * speedFactor);
        PlayWalkAnimation(_rigid.velocity);
        if(Input.GetKeyDown(KeyCode.N))
        {
            GameObject gameObject = new GameObject("Test");
            gameObject.transform.Translate(count, 0, 0);
            count++;
            gameObject.AddComponent<SpriteRenderer>();
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            var sp = Resources.Load<Sprite>("characterdemo");
            Debug.Log(sp);
            sprite.sprite = sp;
            sprite.sortingOrder = 10;
        }

    }

    void Flip(bool isHeadingLeft)
    {
        _spriteRenderer.flipX = !isHeadingLeft;
    }

    void PlayWalkAnimation(Vector2 velocity)
    {
        if (Mathf.Abs(velocity.x) > 0)
        {
            _playerAnimation.Play("SideWalk");
        }
        else if (velocity.y > 0)
        {
            _playerAnimation.Play("UpwardWalk");
        }
        else if (velocity.y < 0)
        {
            _playerAnimation.Play("DownwardWalk");
        }
        else
        {
            _playerAnimation.Play("Idle");
        }
    }
}
