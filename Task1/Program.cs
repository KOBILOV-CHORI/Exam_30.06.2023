List<string> words = new List<string> { "apple", "banana", "orange", "grape", "mango" };
string? result = words.Where(w => w.Length == words.Max(e => e.Length)).FirstOrDefault();
Console.WriteLine(result);