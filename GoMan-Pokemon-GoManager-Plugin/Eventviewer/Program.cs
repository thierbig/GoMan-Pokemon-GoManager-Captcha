using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GoMan.Eventviewer
{
    class Program
    {
        static void Test()
        {
            var listOfStrings = new List<string>() { "pokemongogui.exe" };

            Func<EventLogEntry, bool> condition = b => listOfStrings.All(s => b.Message.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0) && b.EntryType == EventLogEntryType.Error;
            EventLog log = new EventLog("Application");
            var entries = log.Entries.Cast<EventLogEntry>().Where(condition).Select(x => new
            {
                x.EntryType,
                x.CategoryNumber,
                x.TimeGenerated,
                x.InstanceId,
                x.Source,
                x.Message
            }).ToList();

            entries.ForEach(x =>
            {
                Console.WriteLine(x.Message);
                Console.WriteLine(x.EntryType);
            });

            Console.ReadLine();
        }
    }
}
