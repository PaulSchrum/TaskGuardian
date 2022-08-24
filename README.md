# TaskGuardian
FOSS utility exe to kill processes named exceltosqlite64 or arcgisindexingserver if task "arcgispro" is not currently running.

I created this project for myself, and I am now putting it on github for anyone to use as they like. The license is Apache 2.0 (FOSS).
Use at your own risk. It is very short, so you should be able to read the code to see what it is doing, but here is what it does:

If ArcGIS Pro is not running, if the process "exceltosqlite64" is running, it will kill the process. It  checks for this only once every thirty minutes, so it greatly reduces the load on your cpu.
It also looks for and kills "arcgisindexingserver", which may be what is restarting exceltosqlite64 all the time.

This has only been tested on my machine, so use of this software acknowledges and entails that the user nor the user's company will hold me liable for any defects in this software. Though it is pretty simple, and you should read the source code (KillProblemTasks.cs) for youself for assurance.

To use:
Download the repo from github.
Open the repo in VisualStudio 2019. (Other versions will work, but I have not tested it on others.)
Build the repo, then run it.

You may also wish to find where VS has put your 

So long as this problem with exceltosqlite64 persists, you may wish to have this console app running in the background all the time.

