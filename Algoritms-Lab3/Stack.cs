using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms_Lab3
{
    public static class Stack
    {
        private static List<object> stack = new List<object>();
        
        public static void Push(object elem)
        {
            stack.Add(elem);
        }

        public static object Pop()
        {
            if (IsEmpty())
            {
                return null;
            }

            object top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return top;
        }

        public static object Top()
        {
            if (IsEmpty())
            {
                return null;
            }

            return stack[stack.Count - 1];
        }

        public static bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public static List<object> Print()
        {
            return new List<object>(stack);
        }
    }
}
