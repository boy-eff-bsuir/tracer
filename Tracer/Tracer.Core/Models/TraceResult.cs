using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        private Tree<MethodInfo> _tree { get; }
        public TraceResult()
        {
            _tree = new Tree<MethodInfo>(new MethodInfo("root", "root", 0));
        }

        public List<Node<MethodInfo>> GetResult()
        {
            return _tree.Root.Children;
        }

        public void Up()
        {
            _tree.CurrentNode = _tree.CurrentNode.Parent;
        }

        public void Down(MethodInfo info)
        {
            Node<MethodInfo> newNode = new Node<MethodInfo>(info);
            newNode.Parent = _tree.CurrentNode;
            newNode.Data = info;
            _tree.CurrentNode.Children.Add(newNode);
            _tree.CurrentNode = newNode;
        }
    }
}