using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment3_LinkedLists
{
    public class SLL : LinkedListADT
    {
        private Node head;
        private Node tail;
        private int listSize;

        public Node Head { get => head; set => head = value; }
        public Node Tail { get => tail; set => tail = value; }
        public int ListSize { get => listSize; set => listSize = value; }

        public void AddBegin(object data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
            }
            Head = newNode;
            ListSize++;
        }

        public void AddEnd(object data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail!.Next = newNode;
            }
            Tail = newNode;
            ListSize++;
        }

        public void RemoveAt(int index)
        {
            Node current = Head;
            if (index < 0 || index > ListSize)
            {
                throw new EmptyListException(index);
            }
            else
            {
                if (index == 0)
                {
                    RemoveStart();
                }
                else if (index == ListSize - 1)
                {
                    RemoveEnd();
                }
                else
                {
                    for (int i = 0; i <= index; i++)
                    {
                        Console.WriteLine(i);
                        if (i == index-1)
                        {
                            current.Next = current.Next.Next;
                        }
                        current = current.Next;
                    }
                }
                ListSize--;
            }
        }

        public void RemoveStart()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if(Head == null)
                {
                    Tail = null;
                }
                ListSize--;
            }
            else
            {
                throw new EmptyListException();
            }
        }

        public void RemoveEnd()
        {
            if (Head != null)
            {
                if (Head.Next == null)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Node current = Head;
                    while(current.Next!.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }
                ListSize--;
            }
            else
            {
                throw new EmptyListException();
            }
        }

        public void InsertAt(int index, object data)
        {
            Node newNode = new Node(data);
            Node current = Head;
            if (index < 0 || index > ListSize)
            {
                throw new EmptyListException(index);
            }
            else
            {
                if (index == 0)
                {
                    AddBegin(data);
                }
                else if (index == ListSize - 1)
                {
                    AddEnd(data);
                }
                else
                {
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index - 1)
                        {
                            newNode.Next = current.Next;
                            current.Next = newNode;
                        }
                        current = current.Next;
                    }
                }
                ListSize++;
            }
        }

        public void Append(object data)
        {
            listSize++;
            if (FixListNull(data) == true)
            {
                return;
            }
            tail.Next = new Node(data);
            tail = tail.Next;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Console.WriteLine("List cleared");
        }

        public bool Contains(object data)
        {
            Node current = head; //initialize "current"
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true; //data found
                }
                current = current.Next;
            }
            return false; //data not found
            //throw new NotImplementedException();
        }

        public void Delete(int targetIndex)
        {
            if (CheckListNull() is true)
            {
                return;
            }
            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (targetIndex == 0)
                {
                    head = head.Next;
                    return;
                }

                if (index + 1 == targetIndex)
                {
                    if (tempNode.Next == tail)
                    {
                        tail = tempNode;
                        tail.Next = null;
                        return;
                    }
                    else
                    {
                        tempNode.Next = tempNode.Next.Next;
                        return;
                    }
                }
                index++;
            }
        }

        public int IndexOf(object target)
        {
            if (CheckListNull() is true)
            {
                return -1;
            }

            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (tempNode.Data.ToString() == target.ToString())
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public void Insert(object data, int targetIndex)
        {
            listSize++;
            if (targetIndex == 0)
            {
                if (CheckListNull() is true)
                {
                    head = tail = new Node(data);
                }
                else
                { // no work
                    Node temp = head;
                    head = new Node(data, temp);
                }
            }
            if (CheckListNull() is true && targetIndex > 0)
            {
                Console.WriteLine("Target Index Out of Bounds For Linked List");
            }
            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (index + 1 == targetIndex)
                {
                    if (tempNode.Next == tail)
                    {
                        Console.WriteLine("Here");
                        Append(tail.Data);
                        tempNode.Next = new Node(data, tail);
                    }
                    else
                    { // in between
                        Console.WriteLine("IN ELSE");
                        Node temp = tempNode.Next;
                        tempNode.Next = new Node(data, temp);
                    }
                }
                index++;
            }
        }

        public bool IsEmpty()
        {
            if (head is null && tail is null)
            {
                Console.WriteLine("List is Empty.");
                return true;
            }
            return false;
        }

        public void Prepend(object data)
        {
            listSize++;
            if (FixListNull(data) == true)
            {
                return;
            }
            Node new_node = new Node(data);
            new_node.Next = head;
            head = new_node;

            //throw new IndexOutOfRangeException();
        }

        public void Replace(object data, int targetIndex)
        {
            if (CheckListNull() is true)
            {
                return;
            }
            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (targetIndex == 0)
                {
                    head = new Node(data, head.Next);
                    return;
                }

                if (index + 1 == targetIndex)
                {
                    if (tempNode == tail)
                    {
                        tail = new Node(data);
                        return;
                    }
                    else
                    {
                        tempNode.Next = new Node(data, tempNode.Next.Next);
                        tail = tempNode.Next;
                        return;
                    }
                }
                index++;
            }
        }

        public object Retrieve(int targetIndex)
        {
            if (CheckListNull() is true)
            {
                return null;
            }
            if (targetIndex == 0)
            {
                return head.Data;
            }
            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (index + 1 == targetIndex)
                {
                    if (tempNode.Next == tail)
                    {
                        return tail.Data;
                    }
                    else
                    {
                        return tempNode.Next.Data;
                    }
                }
                index++;
            }
            return -1;
        }

        public int Size()
        {
            if (head is null)
            {
                return 0;
            }
            Console.Write(listSize);
            return listSize;
        }

        // EXTRA METHODS


        // print DATA of all Nodes in the Linked List
        public void PrintList()
        {
            if (CheckListNull() is true)
            {
                return;
            }
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                Console.Write(tempNode.Data.ToString() + "  ");
            }
            Console.WriteLine();
        }

        // Return the head as NODE if list not empty
        public Node GetHead()
        {
            if (CheckListNull() is true)
            {
                return null;
            }
            return head;
        }

        // return the tail as NODE if list not empty
        public Node GetTail()
        {
            if (CheckListNull() is true)
            {
                return null;
            }
            return tail;
        }

        // return DATA of all Nodes, print Data of head and tail as well... helps to verify all values
        public void PrintData()
        {
            if (CheckListNull() is true)
            {
                return;
            }
            PrintList();
            Console.WriteLine("\nHEAD: " + GetHead().Data);
            Console.WriteLine("TAIL: " + GetTail().Data + "\n\n");
        }

        // return "List was Null" if list is empty.
        public bool CheckListNull()
        {
            if (head is null && tail is null)
            {
                Console.WriteLine("List was NULL\n\n");
                return true;
            }
            return false;
        }

        // When using a method that ads a Node to the list, if the list is empty run  this method
        // this is useful as there are many methods that add Nodes to the list... this can therefore be used universally
        public bool FixListNull(object data)
        {
            if (head is null && tail is null)
            {
                head = tail = new Node(data);
                return true;
            }
            return false;
        }


    }
}
