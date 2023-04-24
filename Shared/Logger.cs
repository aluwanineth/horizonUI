using System.Text;

namespace HorizonPollyC.Shared
{
    public static class Logger
    {
        

        public static async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Create, FileAccess.Write, FileShare.Write,
                    bufferSize: 8192, useAsync: true);

            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }
    }
}
