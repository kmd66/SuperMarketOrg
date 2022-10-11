using System;
using System.Collections.Concurrent;

namespace Kama.Organization.Core
{
	public enum CommandEnum : int
	{
        Unknown = 0
	}

	public static class Commands
	{
		public static Guid GetCommandID(CommandEnum commandEnum)
		{
			switch(commandEnum)
			{
				default: return Guid.Empty;
			}
		}
	}
}
