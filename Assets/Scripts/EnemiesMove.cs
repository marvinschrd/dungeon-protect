﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour
{
    [SerializeField] float speed;
    Transform Target;
    Vector3 targetPosition;
    Princess princess;
    Vector2 princessPosition;
    void Start()
    {
       // targetPosition = new Vector2(Target.position.x, Target.position.y);
        princess = FindObjectOfType<Princess>();
    }

    enum State
    {
        MOVING_TO_FIRST_TARGET,
        MOVING_TO_PRINCESS
    }
    State state = State.MOVING_TO_FIRST_TARGET;
    void Update()
    {
        switch(state)
        {
            case State.MOVING_TO_FIRST_TARGET:
                if (Vector2.Distance(targetPosition, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                if (Vector2.Distance(targetPosition, transform.position) < 0.1f)
                {
                    state = State.MOVING_TO_PRINCESS;
                }
                break;
            case State.MOVING_TO_PRINCESS:
                princessPosition = princess.GivePosition();
                if (Vector2.Distance(princessPosition, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, princessPosition, speed * Time.deltaTime);
                }
                break;
        }
    }
    public void GetFirstTarget(Transform target)
    {
        Target = target;
        targetPosition = new Vector2(Target.position.x, Target.position.y);
    }
}
