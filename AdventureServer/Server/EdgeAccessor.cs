using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Server.Database
{
    class EdgeAccessor : IEdgeAccessor
    {
        private EdgeProcedure edgeProcedure;
        private KeyEdgeProcedure keyEdgeProcedure;
        private IModelMain model;
        private IDatabase database;

        public EdgeAccessor(IDatabase database, IModelMain model)
        {
            this.database = database;
            this.model = model;
            this.edgeProcedure = new EdgeProcedure(database);
            this.keyEdgeProcedure = new KeyEdgeProcedure(database);
        }

        public Tuple<int, IEdge> GetEdge(Tuple<int, int> edgeValues)
        {
            Tuple<int, string> edgeTuple = this.edgeProcedure.GetEdge(edgeValues.Item2);
            string edgeType = edgeTuple.Item2;
            IEdgeBuilder edgeBuilder = this.model.BuilderFactory.CreateEdgeBuilder(edgeType);
            if (edgeType == "Key")
            {
                Tuple<int, int> tup = this.keyEdgeProcedure.GetEdge(edgeValues.Item2);
                IItem item = database.Access.Item.GetFromItemIndex(tup.Item2);
                edgeBuilder.SetValues(Tuple.Create<int, IItem>(tup.Item1, item));
            }
            else
            {
                edgeBuilder.SetValues(Tuple.Create<int>(edgeTuple.Item1));
            }
            return Tuple.Create<int, IEdge>(edgeValues.Item1, edgeBuilder.Build());
        }

        public IList<Tuple<int, IEdge>> GetEdges(IList<Tuple<int, int>> edgeValues)
        {
            IList<Tuple<int, IEdge>> edges = new List<Tuple<int,IEdge>>();
            foreach(Tuple<int,int> value in edgeValues)
            {
                edges.Add(GetEdge(value));
            }
            return edges;
        }
    }
}
