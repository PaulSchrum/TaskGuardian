using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace TaskGuardian
{
    class KillProblemTasks
    {
        private static int timespan = 30 * 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("TaskGuardian / Kill Problem Tasks now running.");
            while(true)
            {
                var allProcesses = new HashSet<Process>(Process.GetProcesses());
                var exceltosqlite64 = allProcesses
                    .Where(pr => pr.ProcessName.ToLower().Contains("exceltosqlite64")).ToList();
                var arcGISindexingServer = allProcesses
                    .Where(pr => pr.ProcessName.ToLower().Contains("arcgisindexingserver")).ToList();
                var arcGISpro = allProcesses
                    .Where(pr => pr.ProcessName.ToLower().Contains("arcgispro")).FirstOrDefault();

                if(exceltosqlite64.Count == 0 && arcGISindexingServer.Count == 0)
                {
                    //Console.WriteLine($"ExcelToSQLite64 not present at {DateTime.Now}");
                    Thread.Sleep(timespan);
                    continue;
                }


                if(null == arcGISpro)
                {
                    foreach (var process in exceltosqlite64)
                    {
                        process.Kill();
                        Console.WriteLine(
                            $"ExcelToSQLite64 process killed at {DateTime.Now}");
                    }

                    //foreach(var process in arcGISindexingServer)
                    //{
                    //    process.Kill();
                    //    Console.WriteLine("ArcGISindexingServer process killed.");
                    //}
                }
                Thread.Sleep(timespan);
            }
        }
    }
}
