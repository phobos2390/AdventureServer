using System;
namespace Server.Database
{
    interface IEdgeAccessor
    {
        Tuple<int, Shared.Model.IEdge> GetEdge(Tuple<int, int> edgeValues);
        System.Collections.Generic.IList<Tuple<int, Shared.Model.IEdge>> GetEdges(System.Collections.Generic.IList<Tuple<int, int>> edgeValues);
    }
}
