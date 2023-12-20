using System.Data;
using System.Diagnostics;

namespace AOC_2023.DayWorkers
{
    internal class Day20 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<string> input)
            {
                Dictionary<string, IModule> modules = new Dictionary<string, IModule>();
                string[] broadcaster = new string[1];
                foreach (var item in input)
                {
                    var s = item.Split(" -> ");
                    if (item.StartsWith("broadcaster"))
                    {
                        broadcaster = s[1].Split(',').Select(t => t.Trim()).ToArray();
                        continue;
                    }

                    if (item.StartsWith("%"))
                    {
                        modules.Add(s[0].Substring(1), new FlipFlop(s[1].Split(',').Select(t => t.Trim()).ToArray()));
                        continue;
                    }

                    if (item.StartsWith("&"))
                    {
                        var mod = new Conjunction(s[1].Split(',').Select(t => t.Trim()).ToArray());
                        mod.SetInputs(input.Where(w => w.Split(" -> ")[1].Split(',').Contains(s[0].Substring(1))));
                        modules.Add(s[0].Substring(1), mod);
                    }
                }

                List<List<Pulse>> p = new List<List<Pulse>>(); 
                for (int i = 0; i < 1000; i++)
                {
                    List<Pulse> pulses = new List<Pulse>();
                    Pulse pulse = Pulse.Low;
                    pulses.Add(pulse);
                    foreach (var item in broadcaster)
                    {
                        Process(item, "", pulse, modules, pulses, item);
                    }

                    //Check if sequence exists

                    p.Add(pulses);
                }
            }

            return $"Result Part 1: {sum}";
        }

        private void Process(string mod, string prevMod, Pulse pulse, Dictionary<string, IModule> modules, List<Pulse> pulses, string broadcasterItem)
        {
            if (broadcasterItem == mod && !string.IsNullOrEmpty(prevMod))
                return;

            pulses.Add(pulse);

            var module = modules[mod];

            if(module is Conjunction)
                pulse = module.ProcessIncomingPulse((prevMod, pulse));
            else
                pulse = module.ProcessIncomingPulse(pulse);
            foreach (var item in module.NextModules)
                Process(item, mod, pulse, modules, pulses, broadcasterItem);
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<string> input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }

    public enum Pulse
    {
        Low,
        High
    }

    public interface IModule
    {
        public Pulse ProcessIncomingPulse(object obj);
        public string[] NextModules { get; set; }
    }

    public class FlipFlop : IModule
    {
        private bool _isOff;

        public FlipFlop(string[] modules)
        {
            NextModules = modules;
        }

        public string[] NextModules { get; set; }

        public Pulse ProcessIncomingPulse(object obj)
        {
            if (obj is Pulse pulse)
            {
                if (pulse == Pulse.Low)
                {
                    _isOff = !_isOff;

                    if (_isOff)
                        pulse = Pulse.High;

                    return pulse;
                }
            }

            return (Pulse)obj;
        }
    }

    public class Conjunction : IModule
    {
        private Dictionary<string, Pulse> _incomingModules = new Dictionary<string, Pulse>();

        public Conjunction(string[] modules)
        {
            NextModules = modules;
        }

        public string[] NextModules { get; set; }

        public void SetInputs(IEnumerable<string> inputs)
        {
            foreach (var item in inputs)
                if (!_incomingModules.ContainsKey(item))
                    _incomingModules.Add(item, Pulse.Low);
        }

        public Pulse ProcessIncomingPulse(object obj)
        {
            if (obj is (string module, Pulse pulse))
                _incomingModules[module] = pulse;

            return _incomingModules.All(p => p.Value == Pulse.High) ? Pulse.Low : Pulse.High;
        }
    }
}
