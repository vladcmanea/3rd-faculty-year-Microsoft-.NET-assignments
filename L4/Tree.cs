using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Tree
    {
        private Node root = null;

        private bool _insert(ref Node node, int value)
        {
            if (node == null)
            {
                node = new Node(value);
                return true;
            }
            else
            {
                Console.WriteLine("N: " + node.Info);
            }
            if (node.Info < value)
            {
                return _insert(ref node.right, value);
            }
            if (node.Info > value)
            {
                return _insert(ref node.left, value);
            }
            return false;
        }

        public bool Insert(int value)
        {
            return _insert(ref root, value);
        }

        private bool _search(ref Node node, int value)
        {
            if (node == null)
            {
                return false;
            }
            if (node.Info < value)
            {
                return _search(ref node.right, value);
            }
            if (node.Info > value)
            {
                return _search(ref node.left, value);
            }
            return true;
        }        

        public bool Search(int value)
        {
            return _search(ref root, value);
        }

        public void Traverse(Traversal trav)
        {
            trav.traverse(root);
        }
    }
}
