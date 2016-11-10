namespace DoubleLinkedList
{
    public class Node
    {
        // node variables
        private int _data;
        private Node _next;
        private Node _prev;

        // public constructor to create new node
        public Node(int data)
        {
            this._data = data;
        }

        // get or set next node
        public Node Next
        {
            get { return this._next; }
            set { this._next = value; }
        }

        // get or set previous node
        public Node Prev
        {
            get { return this._prev; }
            set { this._prev = value; }
        }

        // get or set node data
        public int Value
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
}