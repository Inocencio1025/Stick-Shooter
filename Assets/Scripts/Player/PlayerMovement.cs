using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Camera cam;
    private Unit unit;

    //Vector2 movement;
    Vector2 mousePos;

    private PlayerControls playercontrols;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playercontrols = GetComponent<PlayerControls>();

        /*
        PlayerControls playerInput = new PlayerControls();
        playerInput.FreeRoam.Enable();
        playerInput.FreeRoam.Attack.performed += Attack;
        */

    }
    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    public void Attack()
    {
        bool isArmed = GetComponentInChildren<FirePoint>().GetComponentInChildren<GunBase>();

        if (!isArmed)
        {
            Debug.Log("You are unarmed");
            return;
        }

        GunBase gun = GetComponentInChildren<FirePoint>().GetComponentInChildren<GunBase>();
        gun.Shoot();
    }


    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //mousePos = Mouse.current.position.ReadValue(); ;

        /*
        if (Input.GetButton("Fire1"))
        {
            GetComponentInChildren<GunBase>().Shoot();
        }

        if (Input.GetButtonDown("SwitchWeapons"))
        {
            unit.SwitchWeapons();
        }
        */

        
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        rb.rotation = angle;
    }

    /*
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    */
}
