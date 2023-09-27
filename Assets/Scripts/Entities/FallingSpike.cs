using Fabio.Level2project.Managers;
using System.Collections;
using UnityEngine;

namespace Fabio.Level2project.Entities
{
    public class FallingSpike : MonoBehaviour
    {
        public ScriptableObjects.FallingSpike FallingSpikeParams;
        private float _timeRemaining;
        private Rigidbody2D _rigidBody;
        private PolygonCollider2D _collider;
        private Vector2 _initialPosition;
        private bool _isRespawning;

        private void Start()
        {
            _timeRemaining = FallingSpikeParams.RespawnCooldown;
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<PolygonCollider2D>();
            _initialPosition = transform.position;
        }
        private void FixedUpdate()
        {
            if (!_isRespawning)
            {
                RaycastHit2D hit = Physics2D.Raycast(_rigidBody.position + Vector2.down * (_collider.points[0].y + 0.01f), Vector2.down, 100f);
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    _rigidBody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                EventManager.Instance.PlayerHit(FallingSpikeParams.Damage);
            }
            else if (collision.transform.gameObject.layer == LayerMask.NameToLayer("World") || _rigidBody.position.y <= -12f)
            {
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn()
        {
            _isRespawning = true;
            _rigidBody.bodyType = RigidbodyType2D.Static;
            _rigidBody.position = new Vector2(_rigidBody.position.x,-50f);            

            while (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                yield return null;
            }
            _rigidBody.position = _initialPosition;
            _timeRemaining = FallingSpikeParams.RespawnCooldown;
            _isRespawning = false;
        }
    }
}
