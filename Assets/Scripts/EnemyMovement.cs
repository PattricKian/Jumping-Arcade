using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    Transform nextPos;
    int nextPosIndex;
    [SerializeField] float Speed;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = Positions[0];
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (transform.position == nextPos.position)
            {
                nextPosIndex++;
                if (nextPosIndex >= Positions.Length)
                {
                    nextPosIndex = 0;
                }
                nextPos = Positions[nextPosIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, Speed * Time.deltaTime);
            yield return null;
        }
    }
}