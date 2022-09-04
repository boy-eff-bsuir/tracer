using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class Node<T> where T : class
    {
        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Parent { get; set; }
        public T Data { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();
    }
}