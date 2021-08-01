using System;

namespace ManagementLogic
{
    public class UsersNode<T>
    {
        //a node has a value and a pointer
        //value - T Value
        //pointer - Next
        public UsersNode(T value)
        {
            //create instance of node and pass in value
            //value will be equal to property Value
            this.Value = value;
        }
        public T Value { get; set; } //value
        public UsersNode<T> Next { get; set; } //pointer - node - hold a ref
    }
}
