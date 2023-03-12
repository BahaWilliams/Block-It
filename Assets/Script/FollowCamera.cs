using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Offset;

    void FixedUpdate()
    {
        transform.position = Player.position + Offset;
    }
}
