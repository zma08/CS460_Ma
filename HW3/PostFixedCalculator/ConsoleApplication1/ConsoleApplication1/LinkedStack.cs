using System;
/**
 * A singly linked stack implementation.
 */
namespace PostFixedCalculator
{
    public class LinkedStack : StackADT
    {
        private Node top;
        public LinkedStack()
        {
            top = null; //empty stack 
        }
        public void Clear()
        {
            top = null;
        }

        public bool IsEmpty()
        {
            return (top == null ? true : false);
        }

        public Object Peek()
        {
            return (IsEmpty() ? null : top.data);
        }

        public Object Pop()
        {
            if (top == null) { return null; }
            Object item = top.data;
            top = top.next;
            return item;
        }

        public Object Push(Object newItem)
        {
            if (newItem == null) { return null; }
            Node aNode = new Node(newItem, top);
            top = aNode;
            return newItem;
        }
    }


}