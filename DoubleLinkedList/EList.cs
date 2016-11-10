using System;

namespace DoubleLinkedList
{
    public class EList : IEList
    {
        private Node _first;
        private Node _last;
        
        // initialize linked list
        public void Clear()
        {
            _first = _last = null;
        }

        public void Init(int[] ini)
        {
            Clear();
            foreach (var i in ini)
            {
                AddEnd(i);
            }
        }

        // convert list to array
        public int[] ToArray()
        {
            var intArr = new int[Size()];
            var i = 0;

            while (_first != null)
            {
                intArr[i] = _first.Value;
                _first = _first.Next;
                i++;
            }

            RestorePointers();
            return intArr;
        }

        // convert linked list to string
        public override string ToString()
        {
            return string.Join(", ", ToArray());
        }

        public int Size()
        {
            var i = 0;
            while (_first != null)
            {
                _first = _first.Next;
                i++;
            }

            RestorePointers();
            return i;
        }

        // add element to the end of the list
        public void AddStart(int val)
        {
            var newNode = new Node(val);

            if (_first == null)
            {
                _first = _last = newNode;
            }

            else
            {
                newNode.Next = _first;
                _first = newNode;
                newNode.Next.Prev = _first;
            }
        }

        // add element to the beginning of the list
        public void AddEnd(int val)
        {
            var newNode = new Node(val);

            if (_first == null)
            {
                _first = _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                newNode.Prev = _last;
                _last = newNode;
            }
        }

        // add node by an index
        public void AddPos(int pos, int val)
        {
            if ((pos != Size() + 1) && (_first == null || !IsWithinRange(pos)))
            {
                throw new InvalidOperationException();
            }

            if (pos == 1) 
            {
                AddStart(val);
            }
            else if (pos == Size() + 1)
            {
                AddEnd(val);
            }
            else
            {
                var nodeWhereAdd = GetNode(pos);
                var newNode = new Node(val);

                nodeWhereAdd.Prev.Next = newNode;
                newNode.Prev = nodeWhereAdd.Prev;
                nodeWhereAdd.Prev = newNode;
                newNode.Next = nodeWhereAdd;
            }
        }

        // delete start position node
        public int DelStart()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }

            var tempNode = _first;
            if (_first.Next != null)
            {
                _first.Next.Prev = null;
            }
            _first = _first.Next;
            return tempNode.Value;
        }

        // delete last node
        public int DelEnd()
        {
            if (_last == null)
            {
                throw new InvalidOperationException();
            }

            var tempNode = _last;
            if (_last.Prev != null)
            {
                _last.Prev.Next = null;
            }
            _last = _last.Prev;
            return tempNode.Value;
        }

        // delete node by position
        public int DelPos(int pos)
        {
            if (!IsWithinRange(pos))
            {
                throw new InvalidOperationException();
            }

            if (pos == 1)
            {
                return DelStart();
            }

            if (pos == Size())
            {
                return DelEnd();
            }

            var nodeToDelete = GetNode(pos);

            nodeToDelete.Prev.Next = nodeToDelete.Next;
            nodeToDelete.Next.Prev = nodeToDelete.Prev;

            return nodeToDelete.Value;
        }

        // get minimal node value
        public int Min()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }

            var min = _first.Value;

            while (_first.Next != null)
            {
                _first = _first.Next;
                if (min > _first.Value)
                {
                    min = _first.Value;
                }
            } 

            RestorePointers();
            return min;
        }

        // get max node value
        public int Max()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }
            
            var max = _first.Value;

            while (_first.Next != null)
            {
                _first = _first.Next;
                if (max < _first.Value)
                {
                    max = _first.Value;
                }
            }

            RestorePointers();
            return max;
        }

        // return first node value
        public int MinPos()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }

            return _first.Value;
        }

        // return last node value
        public int MaxPos()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }

            return _last.Value;
        }

        // sort linked list
        public void Sort()
        {
            var arr = ToArray();
            Array.Sort(arr);
            Init(arr);
        }

        // reverse linked list
        public void Reverse()
        {
            var arr = ToArray();
            Array.Reverse(arr);
            Init(arr);
        }

        // halfreverse functionality
        public void HalfReverse()
        {
            var arr = ToArray();
            var arrHalfLength = (int)Math.Ceiling((double)Size() / 2);

            // if 1 - odd-sized array, if 0 - even-sized array
            var valueToMinus = Size() % 2;

            for (var i = 0; i < arrHalfLength - valueToMinus; i++)
            {
                var temp = arr[i];
                arr[i] = arr[arrHalfLength + i];
                arr[arrHalfLength + i] = temp;
            }

            Init(arr);
        }

        // Ge by index
        public int Get(int pos)
        {
            if (!IsWithinRange(pos))
            {
                throw new InvalidOperationException();
            }

            return GetNode(pos).Value;
        }

        // set new valuse by index
        public void Set(int pos, int val)
        {
            if (!IsWithinRange(pos))
            {
                throw new InvalidOperationException();
            }

            var nodeToSet = GetNode(pos);
            nodeToSet.Value = val;
        }

        // helper
        // method to check if entered position is within valid limit
        private bool IsWithinRange(int pos)
        {
            if (pos < 1 || pos > Size())
            {
                return false;
            }
            return true;
        }

        // helper,
        // gets node from the list by index
        private Node GetNode(int pos)
        {
            var count = 1;
            var node = _first;
            while (node != null && count != pos)
            {
                node = node.Next;
                count++;
            }
            return node;
        }

        // helper,
        // restores pointers to first and last nodes
        private void RestorePointers()
        {
            if (_last == null)
            {
                return;
            }

            _first = _last;
            while (_first.Prev != null)
            {
                _first = _first.Prev;
            }
        }
    }
}