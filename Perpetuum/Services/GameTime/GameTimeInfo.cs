﻿using System;

namespace Perpetuum.Services.Daytime
{
    public class GameTimeInfo
    {
        private const int NIGHT_END = 100;
        //private const int SUNRISE = 150;
        private const int DAY_START = 200;
        private const int DAY_END = 700;
        //private const int SUNSET = 750;
        private const int NIGHT_START = 800;
        private const int DAY_LENGTH = 1000;

        private static readonly double _gameDaySpan = TimeSpan.FromHours(3).TotalHours;

        public static GameTimeInfo FromCurrentTime()
        {
            return FromTime(DateTime.Now);
        }

        public static GameTimeInfo FromTime(DateTime time)
        {
            var currentDayTime = time.TimeOfDay.TotalHours;
            var gtDayFactor = (currentDayTime % _gameDaySpan) / _gameDaySpan;
            var gameTime = (int)(gtDayFactor.Clamp() * DAY_LENGTH);
            return new GameTimeInfo(gameTime);
        }

        public readonly int GameTimeStamp;
        public GameTimeInfo(int gameTime)
        {
            GameTimeStamp = gameTime;
        }

        public enum DayState
        {
            DAY,
            NEUTRAL,
            NIGHT
        }

        public DayState GetDayState()
        {
            if (GameTimeStamp > DAY_START && GameTimeStamp < DAY_END)
            {
                return DayState.DAY;
            } 
            else if (GameTimeStamp > NIGHT_START || GameTimeStamp < NIGHT_END)
            {
                return DayState.NIGHT;
            } 
            else
            {
                return DayState.NEUTRAL;
            }
        }
    }
}
