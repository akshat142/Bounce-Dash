using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;


    //Camera controller
    private void LateUpdate()
    {
        if (player.position.y > transform.position.y + 2f)
        {
            Vector3 targetPosition = new(transform.position.x, player.position.y + offset.y, transform.position.z);
            //using lerp for smoothness
            transform.position = Vector3.Slerp(transform.position, targetPosition, 5f * Time.deltaTime);
        }
    }
}
