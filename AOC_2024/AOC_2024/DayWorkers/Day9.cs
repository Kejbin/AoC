using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day9 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = DefragmentParts(str);

                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        class File
        {
            public int ID { get; set; }
            public int Length { get; set; }
            public int SpaceAfter { get; set; }
            public bool Moved { get; set; }
        }

        private long DefragmentParts(string str)
        {
            var input = str.ToCharArray().Select(s => int.Parse(s.ToString())).ToArray();
            var files = new List<File>();
            var id = 0;
            for (int i = 0; i < input.Length; i += 2)
            {
                files.Add(new File { ID = id, Length = input[i], SpaceAfter = i+1 == input.Length ? 0 : input[i + 1] });
                id++;
            }

            File lastFile = files.Last();
            List<int> checksum = new List<int>();
            var countTo = files.Count;
            for (int c = 0; c < countTo; c++)
            {
                var file = files[c];

                for (int i = 0; i < file.Length; i++)
                    checksum.Add(file.ID);

                if (file.SpaceAfter == 0)
                    continue;

                if (lastFile == file)
                    break;

                while(file.SpaceAfter > 0)
                {
                    if (lastFile.Length == 0)
                    {
                        files.Remove(lastFile);
                        lastFile = files.Last();
                        countTo--;
                    }

                    var takenSpace = file.SpaceAfter - lastFile.Length;
                    if (takenSpace <= 0)
                    {
                        for (int i = 0; i < file.SpaceAfter; i++)
                            checksum.Add(lastFile.ID);

                        lastFile.Length = lastFile.Length - file.SpaceAfter;
                        file.SpaceAfter = 0;
                    }
                    else
                    {
                        for (int i = 0; i < lastFile.Length; i++)
                            checksum.Add(lastFile.ID);

                        file.SpaceAfter = takenSpace;
                        lastFile.Length = 0;
                    }
                }
            }

            var resp = 0L;
            for (int i = 0; i < checksum.Count; i++)
                resp += i * checksum[i];

            return resp;
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();
                
                sum = DefragmentFullFiles(str);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long DefragmentFullFiles(string str)
        {
            var input = str.ToCharArray().Select(s => int.Parse(s.ToString())).ToArray();
            var files = new List<File>();
            var id = 0;
            for (int i = 0; i < input.Length; i += 2)
            {
                files.Add(new File { ID = id, Length = input[i], SpaceAfter = i + 1 == input.Length ? 0 : input[i + 1] });
                id++;
            }

            List<int> checksum = new List<int>();
            var countTo = files.Count;
            for (int c = 0; c < countTo; c++)
            {
                var file = files[c];

                for (int i = 0; i < file.Length; i++)
                {
                    if (file.Moved)
                        checksum.Add(0);
                    else
                        checksum.Add(file.ID);
                }

                if (file.SpaceAfter == 0)
                    continue;

                var space = file.SpaceAfter;
                while (space > 0)
                {
                    var nextFile = files.LastOrDefault(f => f.Length <= space && f.ID > file.ID && !f.Moved);

                    if (nextFile == null)
                    {
                        for (int i = 0; i < space; i++)
                            checksum.Add(0);
                        break;
                    }

                    for (int i = 0; i < nextFile.Length; i++)
                        checksum.Add(nextFile.ID);

                    space -= nextFile.Length;
                    nextFile.Moved = true;
                }
            }

            var resp = 0L;
            for (int i = 0; i < checksum.Count; i++)
                resp += i * checksum[i];

            return resp;
        }
    }
}
