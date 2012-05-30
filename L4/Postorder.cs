using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Postorder : Traversal
    {
        public void traverse(Node node)
        {
            if (node == null)
                return;

            traverse(node.Left);
            traverse(node.Right);
            process(node);
        }

        public void process(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine("Postorder: " + node.Info);
        }
    }
}
