public static class CardExtensions
{
    extension<T>(IEnumerable<T> sequence)
    {
        public IEnumerable<T> InterleaveSequenceWith(IEnumerable<T> second)
        {
            var firstIter = sequence.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }
        public bool SequenceEquals(IEnumerable<T> second)
        {
            var firstIter = sequence.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while ((firstIter?.MoveNext() == true) && secondIter.MoveNext())
            {
                if ((firstIter.Current is not null) && !firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }

            return true;
        }
        public IEnumerable<T> LogQuery(string tag)
        {
            // File.AppendText creates a new file if the file doesn't exist.
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }

            return sequence;
        }
    }
}
