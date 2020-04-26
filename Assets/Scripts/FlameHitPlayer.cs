using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHitPlayer : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        var player = other.GetComponent<PlayerCollisionController>();
        if (player != null)
        {
            player.Hit(0.5f);
        }
    }
}
