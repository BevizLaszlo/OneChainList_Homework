using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneChainList
{
    class OneChainList
    {
        public int Data;
        public OneChainList Prev = null;
        public OneChainList Next = null;

        public OneChainList(int value) 
        {
            Data = value;
        }
    }

    internal class Program
    {
        static OneChainList Head = null;
        static void Main(string[] args)
        {

            OneChainList node1 = new OneChainList(10);
            OneChainList node2 = new OneChainList(20);
            OneChainList node3 = new OneChainList(30);
            OneChainList node4 = new OneChainList(40);
            OneChainList node5 = new OneChainList(50);

            Add(node1);
            Add(node5);
            Add(node3);
            Add(node2);
            Add(node4);
            ShowList();
            Remove(node2);
            ShowList();
            Console.ReadKey();
        }

        private static void Add(OneChainList node)
        {
            OneChainList tempNode = Head;
            if (tempNode == null)
            {
                Head = node;
                return;
            }

            while (tempNode != null)
            {
                if (tempNode.Next == null || tempNode.Next.Data >= node.Data)
                {
                    node.Next = tempNode.Next;
                    node.Prev = tempNode;
                    tempNode.Next = node;
                    break;
                }

                tempNode = tempNode.Next;
            }
        }

        private static void Remove(OneChainList node)
        {
            OneChainList tempNode = Head;
            while (tempNode != null)
            {
                if (tempNode == node)
                {
                    tempNode.Prev.Next = tempNode.Next;
                    break;
                }

                tempNode = tempNode.Next;
            }
        }

        private static void ShowList()
        {
            OneChainList tempNode = Head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.Next;
            }
            Console.WriteLine();
        }
    }
}
