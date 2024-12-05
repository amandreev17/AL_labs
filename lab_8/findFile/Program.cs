using System.Text;
using System.IO.Compression;

string catalog = "/Users/olesaandreeva/Desktop/";
string nameFile = "Test.txt";
string sourceFile = "/Users/olesaandreeva/Desktop/Test.txt";
string compressedFile = "/Users/olesaandreeva/Desktop/compress.gz";
foreach (string file in Directory.EnumerateFiles(catalog, nameFile))
{
    FileStream fileStream = File.OpenRead(file);
    byte[] buffer = new byte[fileStream.Length];
    await fileStream.ReadAsync(buffer, 0, buffer.Length);
    string text = Encoding.Default.GetString(buffer);
    Console.WriteLine(text);
}

FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
FileStream targetStream = File.Create(compressedFile);
GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
await sourceStream.CopyToAsync(compressionStream);
Console.WriteLine($"Сжатие файла {sourceFile} завершено.");
Console.WriteLine($"Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}");