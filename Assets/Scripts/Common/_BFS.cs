using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class _BFS
{
    public class Point
    {
        public int RowIndex;
        public int ColIndex;
        public Point Father;

        public Point(int row,int col)
        {
            this.RowIndex = row;
            this.ColIndex = col;
        }

        public Point(int row,int col,Point father)
        {
            this.RowIndex = row;
            this.ColIndex = col;
            this.Father = father;
        }
    }

    public int RowCount;
    public int ColCount;

    public Dictionary<string, Point> finds;

    public _BFS(int row, int col)
    {
        finds = new Dictionary<string, Point>();
        this.RowCount = row;
        this.ColCount = col;
    }

    public List<Point> Search(int row,int col,int step)
    {
        List<Point> searchs = new List<Point>();
        Point startPoint = new Point(row, col);
        searchs.Add(startPoint);
        finds.Add($"{row}_{col}", startPoint);

        for(int i = 0;i<step;i++)
        {
            List<Point> temps = new List<Point>();
            for(int j = 0;j<searchs.Count;j++)
            {
                Point current = searchs[j];
                FindAroundPoints(current, temps);
            }
            if(temps.Count == 0)
            {
                break;
            }

            searchs.Clear();

            searchs.AddRange(temps);
        }
        return finds.Values.ToList();
    }

    public void FindAroundPoints(Point current,List<Point> temps)
    {
        if(current.RowIndex - 1>= 0)
        {
            AddFinds(current.RowIndex - 1,current.ColIndex,current,temps);
        }
        if(current.RowIndex + 1 < RowCount)
        {
            AddFinds(current.RowIndex + 1, current.ColIndex, current, temps);
        }
        if(current.ColIndex - 1 >= 0)
        {
            AddFinds(current.RowIndex, current.ColIndex-1, current, temps);
        }
        if(current.ColIndex + 1<ColCount)
        {
            AddFinds(current.RowIndex, current.ColIndex+1, current, temps);
        }
    }

    public void AddFinds(int row, int col, Point father, List<Point> temps)
    {
        if (finds.ContainsKey($"{row}_{col}") == false && GameApp.MapManager.GetBlockType(row, col) != BlockType.Obstacle)
        {
            Point p = new Point(row, col, father);

            finds.Add($"{row}_{col}", p);
            temps.Add(p);
        }
    }

    //寻找可移动的点，离终点最近的点的路径集合
    public List<Point> FindMinPath(ModelBase model,int step,int endRowIndex,int endColIndex)
    {
        List<Point> results = Search(model.RowIndex, model.ColIndex, step);//获得能够移动的点的集合

        if (results.Count == 0)
        {
            return null;
        }
        else
        {
            Point minPoint = results[0];//默认一个点为离目标点距离最近
            int min_dis = Mathf.Abs(minPoint.RowIndex - endRowIndex) + Mathf.Abs(minPoint.ColIndex - endColIndex);
            for(int i=1;i<results.Count;i++)
            {
                int temp_dis = Mathf.Abs(results[i].RowIndex - endRowIndex) + Mathf.Abs(results[i].ColIndex - endColIndex);
                if(temp_dis < min_dis)
                {
                    min_dis = temp_dis;
                    minPoint = results[i];
                }
            }
            List<Point> paths = new List<Point>();
            Point current = minPoint.Father;
            paths.Add(minPoint);
            while(current != null)
            {
                paths.Add(current);
                current = current.Father;
            }
            paths.Reverse();//反置
            return paths;
        }
    }
}
