namespace DotNetCore.Objects
{
    public class Page
    {
        public Page()
        {
            Index = 1;
            Size = int.MaxValue;
        }

        public Page(int index, int size)
        {
            Index = index;
            Size = size;
        }

        public int Index { get; set; }

        public int Size { get; set; }
    }
}
