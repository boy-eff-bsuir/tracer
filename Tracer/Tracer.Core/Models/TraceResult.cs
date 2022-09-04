using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        private Tree<MethodInfo> _tree { get; }
        private Node<MethodInfo> _node { get; set; }
        public TraceResult()
        {
            _tree = new Tree<MethodInfo>(new MethodInfo("root", "root"));
            _node = _tree.Root;
        }

        public List<Node<MethodInfo>> Result { get => _tree.Root.Children; }

        public List<Node<MethodInfo>> GetResult()
        {
            return _tree.Root.Children;
        }

        public void Up(int time)
        {
            _node.Data.ExecutionTime = time;
            _node = _node.Parent;
        }

        public void Down(MethodInfo info)
        {
            Node<MethodInfo> newNode = new Node<MethodInfo>(info);
            newNode.Parent = _node;
            newNode.Data = info;
            _node.Children.Add(newNode);
            _node = newNode;
        }
    }
}