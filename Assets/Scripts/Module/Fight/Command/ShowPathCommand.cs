using System.Collections.Generic;
using UnityEngine;

public class ShowPathCommand : BaseCommand
{
    Collider2D pre;
    Collider2D current;
    AStar astar;
    AStarPoint start;
    AStarPoint end;
    List<AStarPoint> prePaths;

    public ShowPathCommand(ModelBase model) : base(model)
    {
        prePaths = new List<AStarPoint>();
        start = new AStarPoint(model.RowIndex, model.ColIndex);
        astar = new AStar(GameApp.MapManager.RowCount,GameApp.MapManager.ColCount);
    }

    public override bool Update(float dt)
    {
        if(Input.GetMouseButtonDown(0))
        {
            //执行移动命令
            if(prePaths.Count != 0 && this.model.Step >= prePaths.Count - 1)
            {
                GameApp.CommandManager.AddCommand(new MoveCommand(this.model,prePaths));
            }
            else
            {
                GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);

                //不移动直接显示操作选项
                //显示选项界面
                GameApp.ViewManager.Open(ViewType.SelectOptionView, this.model.data["Event"], (Vector2)this.model.transform.position);
            }

            return true;
        }

        current = Tools.ScreenPointToRay2D(Camera.main, Input.mousePosition);

        if(current != null)
        {
            if(current != pre)
            {
                pre = current;

                Block b = current.GetComponent<Block>();

                if(b!= null)
                {
                    end = new AStarPoint(b.RowIndex, b.ColIndex);
                    astar.FindPath(start, end, updatePath);
                }
                else
                {
                    for(int i = 0;i<prePaths.Count;i++)
                    {
                        GameApp.MapManager.mapArr[prePaths[i].RowIndex, prePaths[i].ColIndex].SetDirSp(null, Color.white);
                    }
                    prePaths.Clear();
                }
            }
        }

        return false;
    }

    private void updatePath(List<AStarPoint> paths)
    {
        if(prePaths.Count != 0)
        {
            for(int i = 0;i<prePaths.Count;i++)
            {
                GameApp.MapManager.mapArr[prePaths[i].RowIndex, prePaths[i].ColIndex].SetDirSp(null, Color.white);
            }
        }

        if(paths.Count >= 2 && model.Step >= paths.Count - 1)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                BlockDirection dir = BlockDirection.down;

                if(i == 0)
                {
                    dir = GameApp.MapManager.GetDirection1(paths[i], paths[i + 1]);
                }
                else if(i == paths.Count - 1)
                {
                    dir = GameApp.MapManager.GetDirection2(paths[i], paths[i - 1]);
                }
                else
                {
                    dir = GameApp.MapManager.GetDirection3(paths[i - 1], paths[i], paths[i+1]);
                }

                GameApp.MapManager.SetBlockDir(paths[i].RowIndex, paths[i].ColIndex, dir, Color.yellow);
            }
        }

        prePaths = paths;
    }
}
