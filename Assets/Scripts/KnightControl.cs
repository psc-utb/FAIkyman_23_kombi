using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
public class KnightControl : MonoBehaviour
{

    Animator _animator;
    Rigidbody2D _rb2D;

    [SerializeField]
    float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && isAttacking == false)
        {
            _animator.SetTrigger("Attack");
            _animator.SetBool("Moving", false);

            _rb2D.velocity = new Vector2(0, _rb2D.velocity.y);

            isAttacking = true;
        }


        float vx = Input.GetAxisRaw("Horizontal");

        if(vx != 0 && isAttacking == false)
        { 
            _animator.SetBool("Moving", true);

            _rb2D.velocity = new Vector2(vx * speed, _rb2D.velocity.y);
        }
        else
        { 
            _animator.SetBool("Moving", false);

            _rb2D.velocity = new Vector2(0, _rb2D.velocity.y);
        }
    }

    private void LateUpdate()
    {
        if (transform.localScale.x > 0
            && _rb2D.velocity.x < 0
            ||
            transform.localScale.x < 0
            && _rb2D.velocity.x > 0)
        {
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void StopAttack()
    {
        isAttacking = false;
    }
}
