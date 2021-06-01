using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Bricks instance")]
    [SerializeField] GameObject brickPrefab = null;
    [SerializeField] Material[] materials = null;
    [SerializeField] Transform bricksParent = null;
    [Header("Bricks Spawn Positions")]
    [SerializeField] int bricksColumns = 5;
    [SerializeField] int bricksLines = 5;
    [SerializeField] float distanceFromTop = 1f;
    [SerializeField] GameObject topBoundary = null;
    [SerializeField] GameObject leftBoundary = null;
    [SerializeField] GameObject rightBoundary = null;

    private void Start()
    {

        float startingPosY = topBoundary.transform.position.y - (topBoundary.GetComponent<BoxCollider>().size.y / 2) - distanceFromTop;
        float leftStartingPosX = leftBoundary.transform.position.x + leftBoundary.GetComponent<BoxCollider>().size.x / 2;
        float rightEndingPosX = rightBoundary.transform.position.x - rightBoundary.GetComponent<BoxCollider>().size.x / 2;

        float bricksSizeX = (rightEndingPosX - leftStartingPosX) / bricksColumns;
        float bricksSizeY = brickPrefab.GetComponent<BoxCollider>().size.y;

        for (int i = 0; i < bricksColumns; i++)
        {
            for (int j = 0; j < bricksLines; j++)
            {
                Vector3 brickPos = new Vector3(leftStartingPosX + bricksSizeX * i + bricksSizeX / 2, startingPosY - bricksSizeY * j, 0);
                GameObject go = Instantiate(brickPrefab, brickPos, Quaternion.identity);
                go.GetComponentInChildren<Renderer>().material = materials[Random.Range(0, materials.Length)];
                go.transform.parent = bricksParent;
                go.name = "Brick " + i + "-" + j;
            }
        }
    }

}
