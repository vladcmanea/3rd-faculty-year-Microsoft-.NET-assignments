using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Inorder: Traversal
    {
        public void traverse(Node node)
        {
            if (node == null)
                return;

            traverse(node.Left);
            process(node);
            traverse(node.Right);
        }

        public void process(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine("Inorder: " + node.Info);
        }   
    }
}
