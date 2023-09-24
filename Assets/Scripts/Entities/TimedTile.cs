using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.Entities
{
    public class TimedTile : MonoBehaviour
    {
        public Fabio.Level2project.ScriptableObjects.TimedTile TimedTileParams;
        private float _timeRemaining;
        private SpriteRenderer _renderer;

        private void Start()
        {
            _timeRemaining = TimedTileParams.Timer;
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                switch (_timeRemaining)
                {
                    case (<= 0f):
                        Destroy(gameObject);
                        break;
                    case (<= 1f):
                        _renderer.color = new Color(1, 0.30f, 0);
                        break;
                    case (<= 2f):
                        _renderer.color = Color.yellow;
                        break;
                    case (> 2f):
                        _renderer.color = Color.green;
                        break;
                }
                _timeRemaining -= Time.fixedDeltaTime;
            }
        }
    }
}
