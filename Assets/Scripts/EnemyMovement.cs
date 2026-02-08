using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float moveTime = 2f;
    [SerializeField] float timer;
    private Vector2 movementDirection = new Vector2(1, 0);
    private void Start()
    {
        speed= Random.Range(1, 2);
        timer = moveTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        transform.Translate(movementDirection * speed * Time.deltaTime);

        if(timer <= 0)
        {
            movementDirection = -movementDirection;
            timer = moveTime;
        }
    }

}
