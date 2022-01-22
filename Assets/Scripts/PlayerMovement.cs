using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    #region Public Field
    public float moveSpeed;
    public Rigidbody2D rb;
    public Text coinText;
    public static int coinCnt = 0;
    #endregion

    #region private Field
    private Vector2 moveDirection;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        coinText.text = "Coin: " + coinCnt;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(moveX, moveY, 0).normalized;



    }

    private void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed,0);
    
    
    }
    
}
