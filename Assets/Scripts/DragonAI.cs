using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragonAI : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rb2D;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    Transform target;

    [SerializeField]
    float distanceToAttack = 2;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    float direction;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = target.position.x - this.transform.position.x;
            direction = Mathf.Sign(distance);

            if (Mathf.Abs(distance) < distanceToAttack && isAttacking == false)
            {
                _animator.SetTrigger("Attack");
                _animator.SetBool("Moving", false);

                _rb2D.velocity = new Vector2(0, _rb2D.velocity.y);

                isAttacking = true;
            }
            else if (isAttacking == false)
            {
                _animator.SetBool("Moving", true);

                _rb2D.velocity = new Vector2(direction * speed, _rb2D.velocity.y);
            }
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
            && direction < 0
            ||
            transform.localScale.x < 0
            && direction > 0)
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
