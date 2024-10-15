using System;
using System.Text;
using Perpetuum.Timers;
using Perpetuum.Zones;

namespace Perpetuum.Services.Weather
{
    public class WeatherInfo
    {
        private const int BAD_WEATHER = 200;
        private const int GOOD_WEATHER = 100;

        public const int WORST_WEATHER = 254;
        public const int BEST_WEATHER = 0;

        public readonly int Current;
        public readonly int Next;

        private readonly TimeTracker _timer;

        public WeatherInfo(int current, int next, TimeSpan duration)
        {
            Current = current;
            Next = next;
            _timer = new TimeTracker(duration);
        }

        public bool Update(TimeSpan elapsed)
        {
            _timer.Update(elapsed);
            return _timer.Expired;
        }

        public Packet CreateUpdatePacket()
        {
            var packet = new Packet(ZoneCommand.Weather);
            packet.AppendByte(0); // ez lesz majd a 
            packet.AppendByte((byte)Current);
            packet.AppendByte((byte)Next);
            packet.AppendLong((long)_timer.Elapsed.TotalMilliseconds);
            packet.AppendLong((long)_timer.Duration.TotalMilliseconds);
            return packet;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Command:{0}, current:{1}, next:{2}, elapsed:{3}, duration:{4}",
                ZoneCommand.Weather, Current, Next, _timer.Elapsed.TotalSeconds, _timer.Duration.TotalSeconds);
            return sb.ToString();
        }

        public enum WeatherState
        {
            GOOD_WEATHER,
            NEUTRAL_WEATHER,
            BAD_WEATHER
        }

        public WeatherState getWeatherState()
        {
            if(Current > BAD_WEATHER && Next > BAD_WEATHER)
            {
                return WeatherState.BAD_WEATHER;
            } 
            else if (Current < GOOD_WEATHER && Next < GOOD_WEATHER)
            {
                return WeatherState.GOOD_WEATHER;
            }
            else
            {
                return WeatherState.NEUTRAL_WEATHER;
            }
        }
    }
}