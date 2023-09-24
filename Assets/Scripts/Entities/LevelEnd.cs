using Fabio.Level2project.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.Entities
{
    public class LevelEnd : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            EventManager.Instance.StageClear();
        }
    }
}
