using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traversal
{
    class Node
    {
        private int info;
        public Node left = null, right = null;

        public int Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        public Node Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public Node Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public Node(int info, ref Node left, ref Node right):this(info)
        {
            this.left = left;
            this.right = right;
        }

        public Node(int info)
        {
            this.info = info;
        }
    }
}
