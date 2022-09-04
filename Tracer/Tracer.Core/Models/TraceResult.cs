using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        private MethodInfo _rootMethodInfo = new MethodInfo("root", "root");
        private IReadOnlyDictionary<int, Tree<MethodInfo>> _methods
            = new ConcurrentDictionary<int, Tree<MethodInfo>>();
        private ConcurrentDictionary<int, Tree<MethodInfo>> _methodsByThreadId ;

        public IReadOnlyList<Tree<MethodInfo>> GetResult()
        {
            return _methodsByThreadId.Values.ToList().AsReadOnly();
        }

        public void Up(long time)
        {
            var tree = GetCurrentThreadTree();
            tree.CurrentNode.Data.ExecutionTime = time;
            tree.CurrentNode = tree.CurrentNode.Parent;
        }

        public void Down(MethodInfo info)
        {
            var tree = GetCurrentThreadTree();
            Node<MethodInfo> newNode = new Node<MethodInfo>(info);
            newNode.Parent = tree.CurrentNode;
            newNode.Data = info;
            tree.CurrentNode.Children.Add(newNode);
            tree.CurrentNode = newNode;
        }

        public MethodInfo GetCurrentMethod()
        {
            var tree = GetCurrentThreadTree();
            return tree.CurrentNode.Data;
        }

        private Tree<MethodInfo> GetCurrentThreadTree()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (!_methodsByThreadId.ContainsKey(threadId))
            {
                _methodsByThreadId.TryAdd(threadId, new Tree<MethodInfo>(threadId, _rootMethodInfo));
            }
            return _methodsByThreadId[threadId];
        }
    }
}