

This projects demostrates CPU impact of [DateTime.Now Property (System) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.now?view=net-8.0#remarks), [DateTime.UtcNow Property (System) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.utcnow?view=net-8.0), [Stopwatch Class (System.Diagnostics) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0), [WaitHandle.WaitOne Method (System.Threading) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.threading.waithandle.waitone?view=net-7.0)  when used in wait operations from Sync method calling Async -  [Calling Synchronous Methods Asynchronously - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously#defining-the-test-method-and-asynchronous-delegate)

Here is the CPU performance of each project using [microsoft/perfview: PerfView is a CPU and memory performance-analysis tool (github.com)](https://github.com/microsoft/perfview):

Syncasyncwait
![Syncasyncwait](Assets/Syncasyncwait.png)

SyncDateTimeNow
![SyncDateTimeNow](Assets/SyncDateTimeNow.png)

SyncDateTimeNowwithDelay
![SyncDateTimeNowwithDelay.png](Assets/SyncDateTimeNowwithDelay.png)

SyncDateTimeUTCNow
![SyncDateTimeUTCNow](Assets/SyncDateTimeUTCNow.png)

SyncStopWatch
![SyncStopWatch](Assets/SyncStopWatch.png)

![image](https://github.com/mndxt007/SyncAsyncWait/blob/master/Assests/Perfview.png)
