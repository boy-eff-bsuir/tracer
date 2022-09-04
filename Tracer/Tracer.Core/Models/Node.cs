using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class Node<T> where T : class
    {
        public Node(T data)
        {
            Data = data;
        }

        [JsonIgnore]
        public Node<T> Parent { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("children")]
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();
    }
}