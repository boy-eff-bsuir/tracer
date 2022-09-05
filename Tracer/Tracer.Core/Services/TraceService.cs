using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Extensions;
using Tracer.Core.Interfaces;
using Tracer.Core.Models;

namespace Tracer.Core.Services
{
    public class TraceService : ITraceService
    {
        private MethodInfo _rootMethodInfo = new MethodInfo("root", "root");
        private ConcurrentDictionary<int, Tree<MethodInfo>> _methodsByThreadId 
            = new ConcurrentDictionary<int, Tree<MethodInfo>>();

        public TraceResult GetResult()
        {
            var methods = _methodsByThreadId.Values.Select(x => x.ToThreadInfoResult().ToDto()).ToList();
            return new TraceResult(methods);
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