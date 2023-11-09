using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(string newEntry)
    {

    }
    public void DisplayAll()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }
    public string SaveToFile(string file, List<Entry> entries)
    {
        string fileName = file;

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach ( Entry e in _entries)
            {
                outputFile.WriteLine($"{e._date},, {e._promptText},, {e._entryText}");
            }
            
        }
        return fileName;
    }
    public string LoadFromFile(string file)
    {

        string fileName = file;

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            // line will have look something like this: "date, prompt, entry"
            string[] parts = line.Split(",,");

            // parts[0] - date
            // parts[1] - prompt
            // parts[2] - entry

            Entry newEntry = new Entry();
            newEntry._date = parts[0];
            newEntry._promptText = parts[1];
            newEntry._entryText = parts[2];

            _entries.Add(newEntry);
        }

        return file;
    }
}


