using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Preorder : Traversal
    {
        public void traverse(Node node)
        {
            if (node == null)
                return;

            process(node);
            traverse(node.Left);
            traverse(node.Right);
        }

        public void process(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine("Preorder: " + node.Info);
        }
    }
}
