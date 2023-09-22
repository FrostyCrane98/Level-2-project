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

        private void Update()
        {
            //use raycast instead of collider
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            switch (_timeRemaining)
            {
                case (<= 0):
                    Destroy(gameObject);
                    return;
                case (<= 1):
                    _renderer.color = Color.red;
                    return;
                case (<= 2):
                    _renderer.color = Color.yellow;
                    return;
                case (> 2):
                    _renderer.color = Color.green;
                    return;
            }
        }
    }
}
