﻿using System;


/**
 * A simple singly linked node class.  
 */
namespace PostFixedCalculator
{
    public class Node
    {
        //public Object data;
           
        public Object data{ get; set; } //The payload
        public Node next { get; set; }//Reference to the next Node in the chain

        public Node()
        {
            data = null;
            next = null;
        }

       

        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }

    }

}