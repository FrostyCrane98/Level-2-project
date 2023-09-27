using Fabio.Level2project.Managers;
using Fabio.Level2project.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.Entities
{
    public class JumpingEnemy : MonoBehaviour
    {
        public ScriptableObjects.JumpingEnemy JumpingEnemyParams;
        private Rigidbody2D _rigidBody;
        private CircleCollider2D _collider;
        private float _timeRemaining;
        private bool _isGrounded = true;
        private Vector2 _initialPosition;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();
            _initialPosition = transform.position;
        }
        private void FixedUpdate()
        {        
            JumpReset();

            if (_isGrounded)
            {
                if (_timeRemaining <= 0) 
                {                   
                    _rigidBody.AddForce(Vector2.up * JumpingEnemyParams.JumpForce, ForceMode2D.Impulse);                    
                }
                else
                {
                    _timeRemaining -= Time.fixedDeltaTime;
                }
            }

            if (transform.position.y <= -12f)
            {
                _rigidBody.velocity = Vector2.zero;
                transform.position = _initialPosition;
            }
        }

        private void JumpReset()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidBody.position + Vector2.down * (_collider.radius + 0.01f), Vector2.down);

            if (hit.distance <= 0.01 && _rigidBody.velocity.y <= 0)
            {
                if (!_isGrounded)
                {
                    _isGrounded = true;
                    _timeRemaining = JumpingEnemyParams.JumpingTimer;
                }
            }
            else
            {
                if (_isGrounded)
                {
                    _isGrounded = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                EventManager.Instance.PlayerHit(JumpingEnemyParams.Damage);
            }
        }
    }
}
