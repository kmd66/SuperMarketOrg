using System;
using System.Collections.Concurrent;

namespace Kama.Organization.Core.Model
{
	public enum OrganizationCommands : short
	{
		Unknown = 0,
	}
	public class CommandDictionary
	{
		public static Guid GetCommandID(OrganizationCommands command)
		{
			var _items = new ConcurrentDictionary<OrganizationCommands, Guid>()
			{
				[OrganizationCommands.Unknown] = Guid.Empty,
			};

			return _items[command];
		}
	}
}
