using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;

    private float speedFactor = 3.0f;

    [SerializeField] private Tilemap _tilemap;
    private Tile _tileBase;
    private bool isClickedOnce;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        isClickedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Flip(horizontalInput < 0);
        _rigid.velocity = new Vector2(horizontalInput * speedFactor, verticalInput * speedFactor);
        PlayWalkAnimation(_rigid.velocity);

        /*-------------*/

        if (Input.GetMouseButtonDown(0) && isClickedOnce == false)
        {
            Object pal = Resources.Load("Sprites/Environments/Tilemaps/Palettes/Ground");
            Debug.Log(pal);
            /*
            GameObject gameObject = new GameObject("Crop");
            gameObject.transform.Translate(newPos);
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<Crops>();

            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            Sprite[] sp = Resources.LoadAll<Sprite>("Sprites/Environments/Tilemaps/Palettes/Ground");
            _tileBase = new Tile();
            _tileBase.sprite = sp[0];
            _tilemap.SetTile(Vector3Int.FloorToInt(newPos), _tileBase);
            isClickedOnce = true;
            */          
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isClickedOnce = false;
        }
        else if (isClickedOnce)
        {
            Vector3 oldPos = newPos;
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            _tilemap.SetTile(Vector3Int.FloorToInt(oldPos), null);
            _tilemap.SetTile(Vector3Int.FloorToInt(newPos), _tileBase);
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
