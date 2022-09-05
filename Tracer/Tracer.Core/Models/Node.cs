using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

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
        internal List<Node<T>> Children { get; set; } = new List<Node<T>>();
    }
}