﻿/*
 * Copyright 2010 Joern Schou-Rode
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using NCrontab;

namespace NCron.Fluent.Crontab
{
    /// <summary>
    /// Implements the <see cref="ISchedule"/> interface using the <see cref="NCrontab.CrontabSchedule"/> class to compute the schedule.
    /// </summary>
    internal class CrontabScheduleAdapter : ISchedule
    {
        private readonly CrontabSchedule _schedule;

        /// <summary>
        /// Creates a new instance of the <see cref="CrontabScheduleAdapter"/> class with a specified crontab expression.
        /// </summary>
        /// <param name="crontab">The crontab expression describing the schedule in witch the job should be executed.</param>
        public CrontabScheduleAdapter(string crontab)
        {
            _schedule = CrontabSchedule.Parse(crontab);
        }

        public DateTime GetNextOccurrence(DateTime baseTime)
        {
            return _schedule.GetNextOccurrence(baseTime);
        }
    }
}
