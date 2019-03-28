using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        Sprite [] sp = Resources.LoadAll<Sprite>("Sprites/Environments/Crops");
        sprite.sortingOrder = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            plant();
        }
    }

    protected virtual void plant()
    {
        transform.Translate(2, 0, 0);
    }

    protected virtual void grow()
    {

    }

    protected virtual void harvest()
    {

    }
}
