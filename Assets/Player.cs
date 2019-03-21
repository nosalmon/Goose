using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 3, Input.GetAxisRaw("Vertical") * 3);
    }
}
