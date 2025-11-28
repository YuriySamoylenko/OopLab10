namespace OopProjectPartC.Core
{
    public static class IdGenerator
    {
        private static int count;

        public static int NewId()
        {
            return ++count;
        }
    }
}
