using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateLevel : MonoBehaviour
{
    public UnityEvent onLevelGenerate;
    public Grid grid;
    public GameObject spawnerObjects;
    public bool isDebuging;
    [SerializeField]
    public Vector2Int size;
    public int numberOfspawns;
    
    public bool[,] generateRound(Vector2Int size,int numberOfSpawns)
    {
         bool[,] spawnArray = new bool[size.x,size.y];
        var squaresAmt = size.x * size.y;
        while(numberOfSpawns > 0)
         for(int y = 0; y < spawnArray.GetLength(0); y++)
        {
            for (int x = 0; x < spawnArray.GetLength(1); x++)
            {
                    if (numberOfSpawns > 0 && spawnArray[x, y] != true)
                        if ((int)Random.Range(0, squaresAmt) == 0)
                            spawnArray[x, y] = true;
                    numberOfSpawns--;
                    squaresAmt--;
            }
        }
        if (isDebuging)
        {
            string debugMatrix = "";
            foreach(bool arr in spawnArray)
            {
                debugMatrix += $" ({arr})";
            }
        }
        return spawnArray;
    }
    public void instantiateRound()
    {
        bool[,] spawnArr = generateRound(size, numberOfspawns);
        for(int y = 0; y < spawnArr.GetLength(0); y++)
        {
            for(int x = 0; x < spawnArr.GetLength(1); x++)
            {
                if (spawnArr[x, y])
                {
                    var positon = grid.CellToWorld(new Vector3Int(x, y));

                    Instantiate(gameObject, positon, gameObject.transform.rotation);
                }
            }
        }
      
    }

}
