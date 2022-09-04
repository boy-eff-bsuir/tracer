using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class Tree<T> where T : class
    {
        public Tree(T root)
        {
            Root = new Node<T>(root);
        }
        public Node<T> Root { get; }
    }
}