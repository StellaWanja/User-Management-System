using System;

namespace ManagementLogic
{
    //create generic class
    public class UsersQueue<T>
    {
        //hold head of node
        public UsersNode<T> Head { get; set; }
        //hold tail of node
        public UsersNode<T> Tail { get; set; }

        //add user to bottom
        public UsersNode<T> Enqueue(T value)
        {
            //create instance of node that holds value
            UsersNode<T> node = new UsersNode<T>(value);
            //if head is null,
            //add node
            //and set it to equal tail and head
            if (this.Head == null)
            {
                Head = Tail = node;
                return node;
            }

            //reference to the node after tail is created, thus added node becomes tail
            //item is added to bottom
            this.Tail.Next = node;
            // then we set new tail to node
            this.Tail = node;
            return node;
        }

        //remove user from top
        public T Dequeue()
        {
            //if head is null, throw an exception
            if (Head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        
            //set value to equal the value of head
            T value = this.Head.Value;
            //set the current head to equal the next node
            //thus unlinking the head
            //and removing the head
            this.Head = this.Head.Next;
            return value;
        }

        //display info
        public void Print()
        {
            //set current to equal head
            var current = Head;
            //as long as current/head is not null
            while (current != null)
            {
                //console out the value of the node
                System.Console.Write(current.Value);
                Console.Write(" ");
                //and move through till it gets to the tail
                current = current.Next;
            }
        }
    }
}