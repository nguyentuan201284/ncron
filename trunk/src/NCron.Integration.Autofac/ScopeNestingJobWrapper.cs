﻿/*
 * Copyright 2009, 2010 Joern Schou-Rode
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

using Autofac;
using NCron;

namespace NCron.Integration.Autofac
{
    internal class ScopeNestingJobWrapper : ICronJob
    {
        private readonly IContainer _container;
        private readonly ICronJob _job;

        public ScopeNestingJobWrapper(IContainer container, ICronJob job)
        {
            _container = container;
            _job = job;
        }

        public void Initialize(CronContext context)
        {
            _job.Initialize(context);
        }

        public void Execute()
        {
            _job.Execute();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
