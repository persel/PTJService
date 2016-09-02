using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Message
{
    public class Response<T>
    {
       
        public string success { get; set; }

        public string message { get; set; }

        public int errorcode { get; set; }

        public int total { get; set; }

        public int limit { get; set; }

        public int page { get; set; }

        public int responsetime { get; set; }

        public int time { get; set; }

        //public class ResultList<T>
        //{
        //    // The nested class is also generic on T.
        //    private class Node
        //    {
        //        // T used in non-generic constructor.
        //        public Node(T t)
        //        {
        //            next = null;
        //            data = t;
        //        }

        //        private Node next;
        //        public Node Next
        //        {
        //            get { return next; }
        //            set { next = value; }
        //        }

        //        // T as private member data type.
        //        private T data;

        //        // T as return type of property.
        //        public T Data
        //        {
        //            get { return data; }
        //            set { data = value; }
        //        }
        //    }

        //    private Node head;

        //    // constructor
        //    public ResultList()
        //    {
        //        head = null;
        //    }

        //    // T as method parameter type:
        //    public void AddHead(T t)
        //    {
        //        Node n = new Node(t);
        //        n.Next = head;
        //        head = n;
        //    }

        //    public IEnumerator<T> GetEnumerator()
        //    {
        //        Node current = head;

        //        while (current != null)
        //        {
        //            yield return current.Data;
        //            current = current.Next;
        //        }
        //    }
        //}

        public List<T> result { get; set; }

    }
}
