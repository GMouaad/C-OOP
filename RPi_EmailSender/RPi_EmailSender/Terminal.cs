using System;
using System.Diagnostics;

namespace MessBoxGPIO
{
	public static class Terminal
	{
		public static void ExecuteCommand(string command)
		{
			Process proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = "/bin/bash";
			proc.StartInfo.Arguments = "-c \" " + command + " \"";
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.Start();

			while (!proc.StandardOutput.EndOfStream)
			{
				Console.WriteLine(proc.StandardOutput.ReadLine());
			}

		}
	}
}
