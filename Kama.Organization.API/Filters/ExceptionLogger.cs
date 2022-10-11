﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Kama.Organization.API.Filters
{
    public class ExceptionLogger : IExceptionLogger
    {
        public ExceptionLogger(Core.IEventLogger logger)
        { 
            _logger = logger;
        }
        protected readonly Core.IEventLogger _logger;

        public virtual Task LogAsync(ExceptionLoggerContext context,
                                     CancellationToken cancellationToken)
        {
            _logger?.Error(context.Exception, $"An Error Occurred in {context.Exception.TargetSite}", "");
            return Task.FromResult(0);
        }
    }
}