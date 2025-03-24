using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LinkedLists
{
    public class Node
    {
        private object data;
        private Node next;

        public object Data { get => data; set => data = value; }
        public Node Next { get => next; set => next = value; }

        public Node(object data)
        {
            this.Data = data;
            this.next = null;
        }

        public Node(object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
