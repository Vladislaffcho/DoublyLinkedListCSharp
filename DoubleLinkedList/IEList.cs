namespace DoubleLinkedList
{
    public interface IEList
    {
        void Clear();
        void Init(int[] ini);
        int[] ToArray();
        string ToString();
        int Size();

        void AddStart(int val);
        void AddEnd(int val);
        void AddPos(int pos, int val);
        int DelStart();
        int DelEnd();
        int DelPos(int pos);

        int Min();
        int Max();
        int MinPos();
        int MaxPos();

        void Sort();
        void Reverse();
        void HalfReverse();

        int Get(int pos);
        void Set(int pos, int val);
    }
}