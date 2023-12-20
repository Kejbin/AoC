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
                    mod.SetInputs(input.Where(w => w.Split(" -> ")[1]
                                                    .Split(',')
                                                    .Contains(s[0].Substring(1)))
                                       .Select(ss => ss.Split(" -> ")[0].Substring(1)));
                    modules.Add(s[0].Substring(1), mod);
                }
            }

            return PartOne((broadcaster, modules)) + "\r\n" + PartTwo((broadcaster, modules)) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is (string[] broadcaster, Dictionary<string, IModule> modules))
            {
                List<(int H, int L)> p = new List<(int, int)>();
                for (int i = 0; i < 1000; i++)
                {
                    (int H, int L) pulses = (0,1);
                    Queue<(string Module, string PrevModule, Pulse Pulse)> mods = new Queue<(string, string, Pulse)>(broadcaster.Select(s => (s, "", Pulse.Low)));
                    while (mods.Count > 0)
                    {
                        var mod = mods.Dequeue();

                        if (mod.Pulse == Pulse.Low)
                            pulses.L++;
                        else
                            pulses.H++;

                        if (!modules.ContainsKey(mod.Module))
                            continue;

                        var module = modules[mod.Module];

                        Pulse pulse;
                        if (module is Conjunction)
                            module.ProcessIncomingPulse((mod.PrevModule, mod.Pulse), out pulse);
                        else if (module.ProcessIncomingPulse(mod.Pulse, out pulse))
                            continue;

                        foreach (var item in module.NextModules)
                            mods.Enqueue((item, mod.Module, pulse));
                    }
        
                    p.Add(pulses);
                }

                //846934850 <
                sum = p.Select(s => s.H).Sum() * p.Select(s => s.L).Sum();
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is (string[] broadcaster, Dictionary<string, IModule> modules))
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
        public bool ProcessIncomingPulse(object obj, out Pulse puls);
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

        public bool ProcessIncomingPulse(object obj, out Pulse res)
        {
            res = Pulse.Low;
            if (obj is Pulse pulse)
            {
                if (pulse == Pulse.Low)
                {
                    _isOff = !_isOff;

                    if (_isOff)
                        res = Pulse.High;

                    return false;
                }
            }

            return true;
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

        public bool ProcessIncomingPulse(object obj, out Pulse res)
        {
            if (obj is (string module, Pulse pulse))
                _incomingModules[module] = pulse;

            res = _incomingModules.All(p => p.Value == Pulse.High) ? Pulse.Low : Pulse.High;
            return false;
        }
    }
}

