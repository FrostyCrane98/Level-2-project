using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.ScriptableObjects;
using Fabio.Level2project.Managers;
using Unity.VisualScripting;

namespace Fabio.Level2project.Entities
{
    public class FallingTile : MonoBehaviour
    {
        public ScriptableObjects.FallingTile FallingTileParams;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidBody;
        private Vector2 _initialPosition;
        private bool _isTimerStarted = false;
        private float _timeRemaining;

        private void Start()
        {
            _initialPosition = transform.position;
            _timeRemaining = FallingTileParams.Timer;
            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void FixedUpdate()
        {
            if (transform.position.y <= -12f)
            {
                _rigidBody.bodyType = RigidbodyType2D.Static;
                _isTimerStarted = false;
                _spriteRenderer.color = new Color(0.7f, 0f, 0.4f);
                _timeRemaining = FallingTileParams.Timer;
                transform.position = _initialPosition;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !_isTimerStarted)
            {
                StartCoroutine(Timer());                
            }
        }

        private IEnumerator Timer()
        {
            _spriteRenderer.color = Color.grey;
            _isTimerStarted = true;
            while (_timeRemaining > 0) 
            {
                _timeRemaining -= Time.deltaTime;
                yield return null;
            }
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
