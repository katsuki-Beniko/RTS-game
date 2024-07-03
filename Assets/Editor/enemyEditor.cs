using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


[CanEditMultipleObjects, CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("set position"))
        { 
            Tilemap tileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();
           
            var allPos = tileMap.cellBounds.allPositionsWithin;

            int min_x = 0;
            int min_y = 0;

            foreach (var pos in allPos)
            {
                if (tileMap.HasTile(pos))
                {
                    if (pos.x < min_x) min_x = pos.x;
                    if (pos.y < min_y) min_y = pos.y;
                }
            }

            Enemy enemy = target as Enemy;

            Vector3Int cellPos = tileMap.WorldToCell(enemy.transform.position);

            enemy.RowIndex = Mathf.Abs(min_y - cellPos.y); 
            enemy.ColIndex = Mathf.Abs(min_x - cellPos.x);

            enemy.transform.position = tileMap.CellToWorld(cellPos) + new Vector3(0.5f, 0f, -1);
        }
    }
}   