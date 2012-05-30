using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();
            t.Insert(2);
            t.Insert(1);
            Console.WriteLine(t.Search(1));
            Console.WriteLine(t.Search(3));
            t.Insert(3);
            t.Traverse(new Preorder());
            t.Traverse(new Inorder());
            t.Traverse(new Postorder());
        }
    }
}
