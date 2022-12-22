using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Grid _grid;

    [Space] 
    
    [SerializeField] private Vector2Int _size;

    private List<List<CellController>> _cells;
    private Dictionary<Vector2Int, Wall> _directionMap = new Dictionary<Vector2Int, Wall>{{Vector2Int.down, Wall.Bottom}, {Vector2Int.up, Wall.Top}, {Vector2Int.left, Wall.Left}, {Vector2Int.right, Wall.Right}};

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        _cells = new List<List<CellController>>();
        var visited = new List<List<bool>>();
        var path = new Stack<Vector2Int>();

        for (int y = 0; y < _size.y; ++y)
        {
            _cells.Add(new List<CellController>());
            visited.Add(new List<bool>());
            for (int x = 0; x < _size.x; ++x)
            {
                var cell = Instantiate(_cellPrefab, _grid.CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity, _grid.transform).GetComponent<CellController>();
                _cells[y].Add(cell);
                visited[y].Add(false);
            }
        }

        var currentPoint = new Vector2Int(Random.Range(0, _size.x), Random.Range(0, _size.y)) * 0;

        do
        {
            var dir = GetAvailablePath();

            if (dir == Vector2.zero)
            {
                if (path.Count == 0)
                    break;

                currentPoint -= path.Pop();
                continue;
            }

            path.Push(dir);
            _cells[currentPoint.y][currentPoint.x].ToggleWall(false, _directionMap[dir]);
            visited[currentPoint.y][currentPoint.x] = true;
            currentPoint += dir;
            _cells[currentPoint.y][currentPoint.x].ToggleWall(false, _directionMap[-dir]);
            visited[currentPoint.y][currentPoint.x] = true;
        } while (path.Count > 0);
        
        Vector2Int GetAvailablePath()
        {
            var cells = new List<Vector2Int>();

            if (currentPoint.x > 0 && !visited[currentPoint.y][currentPoint.x - 1])
                cells.Add(Vector2Int.left);
            
            if (currentPoint.y > 0 && !visited[currentPoint.y - 1][currentPoint.x])
                cells.Add(Vector2Int.down);
            
            if (currentPoint.x < _size.x - 1 && !visited[currentPoint.y][currentPoint.x + 1])
                cells.Add(Vector2Int.right);
            
            if (currentPoint.y < _size.y - 1 && !visited[currentPoint.y + 1][currentPoint.x])
                cells.Add(Vector2Int.up);

            return cells.Count > 0 ? cells[Random.Range(0, cells.Count)] : Vector2Int.zero;
        }
    }
}
