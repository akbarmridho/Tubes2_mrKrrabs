
using System;
using System.Collections.Generic;

namespace mrKrrabs.Solver;

public abstract class BaseSolver : ISolver
{
    // Attributes
    protected MazeMap mazeMap;
    protected MovementHistory movement;
    private List<List<int>> visitedCount = new();
    protected Route currRoute;
    protected bool TSP; 
    
    // Method
    public BaseSolver(MazeMap m, bool TSP)
    {
        this.mazeMap = m;
        this.movement = new(m);
        this.TSP = TSP;

        /* Mengisi visitiedCount dengan angka 0 */
        for(int i = 0; i < m.size; i++)
        {
            List<int> list2 = new List<int>();
            for(int j = 0; j < m.size; j++)
            {
                list2.Add(0);
            }
            this.visitedCount.Add(list2);
        }
        // AddCoordinate(new Route(false, m.StartPosition));
    }

    public MovementHistory getResult() {
        return this.movement;
    }
    
    protected bool Moveable(Coordinate c)
    {
        if(c.X < 0 || c.X >= mazeMap.size || c.Y < 0 || c.Y >= mazeMap.size)
        {
            return false;
        }

        if (mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure || mazeMap.GetElement(c) == Element.KrustyKrab)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    protected void setVisited(Coordinate c)
    {
        this.visitedCount[c.Y][c.X]++;
    }
    
    protected int getVisited(Coordinate c1)
    {
        return this.visitedCount[c1.Y][c1.X];
    }
    
    protected List<Tuple<int, Movement, Route>> AvailableMovement(Route route)
    {
        List<Tuple<int, Movement, Route>> list = new();

        var top = route.CurrentCoordinate.Top();
        if (this.Moveable(top))
        {
            bool isTreasure = mazeMap.GetElement(top) == Element.Treasure;
            var newRoute = new Route(isTreasure, top, route);
            Tuple<int, Movement, Route> t = new(this.getVisited(top), Movement.UP, newRoute);
            list.Add(t);
        }

        var left = route.CurrentCoordinate.Left();
        if (this.Moveable(left))
        {
            bool isTreasure = mazeMap.GetElement(left) == Element.Treasure;
            var newRoute = new Route(isTreasure, left, route);
            Tuple<int, Movement, Route> l = new(this.getVisited(left), Movement.LEFT, newRoute);
            list.Add(l);
        }

        var bottom = route.CurrentCoordinate.Bottom();
        if (this.Moveable(bottom))
        {
            bool isTreasure = mazeMap.GetElement(bottom) == Element.Treasure;
            var newRoute = new Route(isTreasure, bottom, route);
            Tuple<int, Movement, Route> b= new(this.getVisited(bottom), Movement.DOWN, newRoute);
            list.Add(b);
        }

        var right = route.CurrentCoordinate.Right();
        if (this.Moveable(right))
        {
            bool isTreasure = mazeMap.GetElement(right) == Element.Treasure;
            var newRoute = new Route(isTreasure, right, route);
            Tuple<int, Movement, Route> r = new(this.getVisited(right), Movement.RIGHT,newRoute);
            list.Add(r);
        }

        return list;
    }

    protected abstract void AddAvailableMovement(Route route);
    protected abstract void Visit();
    public abstract void Solve();


}