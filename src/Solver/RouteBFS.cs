using System.Collections.Generic;

namespace mrKrrabs.Solver;

public class RouteBFS : Route
{
    // Attributes
    public List<List<int>> visitedCountRoute = new();

    // Methods
    public int getVisitedRoute(Coordinate c)
    {
        return visitedCountRoute[c.Y][c.X];
    }

    public void setVisitedRoute(Coordinate c)
    {
        this.visitedCountRoute[c.Y][c.X]++;
    }

    public RouteBFS(bool isTreasure, Coordinate c, MazeMap m) : base(isTreasure, c)
    {
        for (int i = 0; i < m.size; i++)
        {
            List<int> list2 = new List<int>();
            for (int j = 0; j < m.size; j++)
            {
                list2.Add(0);
            }
            visitedCountRoute.Add(list2);
        }
    }

    public RouteBFS(bool isTreasure, Coordinate c, RouteBFS prev) : base(isTreasure, c, prev)
    {
        for (int i = 0; i < prev.visitedCountRoute.Count; i++)
        {
            visitedCountRoute.Add(new(prev.visitedCountRoute[i]));
        }
    }
}