namespace Application.Client.Extensions
{
    public static class StringExtensions
    {
        public static string GetTitle(this string content)
        {
            using (var reader = new System.IO.StringReader(content))
            {
                var line = reader.ReadLine()?.Trim();
                while (line != null)
                {
                    if (!line.StartsWith('#'))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    return line.Replace("#", string.Empty).Trim();
                }
            }
            return string.Empty;
        }

        public static string GetDescription(this string content)
        {
            using (var reader = new System.IO.StringReader(content))
            {
                var line = reader.ReadLine()?.Trim();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    return line.Trim();
                }
            }
            return string.Empty;
        }
    }
}