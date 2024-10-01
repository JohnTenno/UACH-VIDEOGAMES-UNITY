using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JazirSpawn : MonoBehaviour
{
    [SerializeField] protected bool isRightMovement = true;
    [SerializeField] protected Transform container;

    [SerializeField] protected GameObject turtlePrefab;


    public void Spawn()
    {
        Vector3 position = new Vector3(
            transform.position.x,
            GetRandomHeightPosition(transform.position.y),
            transform.position.z
        );

        GameObject turtle = Instantiate(
            turtlePrefab,
            position,
            turtlePrefab.transform.rotation,
            container.transform
        );

        TurtleMovementFix turtleMovement = turtle.GetComponent<TurtleMovementFix>();
        turtleMovement.isRightMovement = isRightMovement;
    }

    float GetRandomHeightPosition(float origin)
    {
        float cameraHeight = Camera.main.orthographicSize;
        float min = origin;
        float max = origin + cameraHeight + 2;

        float randomValue = Random.Range(min, max);
        return randomValue;
    }
}
