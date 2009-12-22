﻿/* Copyright (c) 2008, Joern Schou-Rode <jsr@malamute.dk>

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE. */

using System;
using System.ServiceProcess;
using NCron.Framework;
using NCron.Service.Configuration;
using NCron.Framework.Scheduling;

namespace NCron.Service
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            XmlConfiguration config = NCronSectionHandler.GetConfiguration();

            if (args.Length == 0)
            {
                CronService service = new CronService(config.Timers);
                ServiceBase.Run(service);
            }
            else
            {
                switch (args[0].ToLowerInvariant())
                {
                    case "debug":
                        CronService service = new CronService(config.Timers);
                        service.StartAllTimers();
                        break;

                    case "exec":
                        foreach (ICronJob job in config.GetJobs(args[1]))
                        {
                            job.Initialize();
                            job.Execute();
                        }
                        break;

                    default:
                        throw new ApplicationException("");
                }
            }
        }
    }
}