using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class Tree<T> where T : class
    {
        public Tree(int id, T root)
        {
            Id = id;
            Root = new Node<T>(root);
            CurrentNode = Root;
        }
        
        public int Id { get; set; }
        public Node<T> Root { get; }
        public Node<T> CurrentNode { get; set; }
    }
}