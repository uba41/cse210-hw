using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void Display()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                //mood is other information in the journal entry
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{entry.Mood}");
            }
        }
        Console.WriteLine($"Jornal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            string[] parts = line.Split(new string[] {"~|~"}, StringSplitOptions.None);
            if (parts.Length == 4)
            {
                entries.Add(new Entry(parts[1], parts[2], parts[0],parts[3]));
            }
        }

        Console.WriteLine($"Jornal loaded from {filename}");
    }

    // Ex= Save or load your document to a database or use a different library or format such as JSON for storage.
    public void SaveToJson(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(entries, options);
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal saved to {filename} (JSON format)");
    }

    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json);
        Console.WriteLine($"Journal loaded from {filename} (JSON format)");
    }

    // EX = Think of other problems that keep people from writing in their journal and address one of those.
    // EX = At program start, check if the latest journal entry is today. If not, prompt a reminder.
    public bool HasEntries()
    {
        return entries.Count > 0;
    }

    public string LastEntryDate()
    {
        return entries[entries.Count - 1].Date;
    }

    // EX = Think of other problems that keep people from writing in their journal and address one of those.
    // Ex= Let the user find past entries easily
    public List<Entry> SearchByKeyword(string keyword)
    {
        List<Entry> results = new List<Entry>();
        foreach (Entry entry in entries)
        {
            if (entry.Response.ToLower().Contains(keyword) || entry.Prompt.ToLower().Contains(keyword))
            {
                results.Add(entry);
            }
        }
        return results;
    } 
}