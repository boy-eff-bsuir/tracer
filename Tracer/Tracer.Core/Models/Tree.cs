using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class Tree<T> where T : class
    {
        public Node<T> Root { get; set; }
        public Tree(T root)
        {
            CurrentNode = new Node<T>();
        }

        public Node<T> CurrentNode { get; set; }
        public void GoToParent()
        {
            CurrentNode = CurrentNode.Parent;
        }

        public void CreateChild(T obj)
        {
            Node<T> newNode = new Node<T>();
            newNode.Parent = CurrentNode;
            newNode.Object = obj;
            CurrentNode.Children.Add(newNode);
            CurrentNode = newNode;
        }
    }
}