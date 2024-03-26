using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoBase : MonoBehaviour
{
    public float velocidad;
    Vector2 movimiento;
    public Vector2 mousePos;
    private bool estaChocando;
    Rigidbody2D rb;
    public Camera cam;
    private Animator animator;
    [SerializeField] DashBar dashBar;
    private bool canDash;
    private bool isDashing;
    private float dashCooldownTimer = 0f;
    [SerializeField] private float dashingPower = 25.0f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canDash = true;
    }

    void Update()
    {
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
            dashBar.UpdateDashBar(dashingCooldown);
            dashCooldownTimer = dashingCooldown;
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movimiento.x * velocidad, movimiento.y * velocidad);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        velocidad *= dashingPower;
        yield return new WaitForSeconds(dashingTime);
        velocidad /= dashingPower;
        isDashing = false;
    }
}