﻿using System;
using Cake.Core.Diagnostics;

namespace Cake.Core
{
    /// <summary>
    /// The default execution strategy.
    /// </summary>
    public sealed class DefaultExecutionStrategy : IExecutionStrategy
    {
        private readonly ICakeLog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultExecutionStrategy"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public DefaultExecutionStrategy(ICakeLog log)
        {
            _log = log;
        }

        /// <summary>
        /// Performs the setup.
        /// </summary>
        /// <param name="action">The action.</param>
        public void PerformSetup(Action action)
        {
            if (action != null)
            {
                _log.Information(string.Empty);
                _log.Information("----------------------------------------");
                _log.Information("Setup");
                _log.Information("----------------------------------------");
                _log.Verbose("Executing custom setup action...");

                action();
            }
        }

        /// <summary>
        /// Performs the teardown.
        /// </summary>
        /// <param name="action">The action.</param>
        public void PerformTeardown(Action action)
        {
            if (action != null)
            {
                _log.Information(string.Empty);
                _log.Information("----------------------------------------");
                _log.Information("Teardown");
                _log.Information("----------------------------------------");
                _log.Verbose("Executing custom teardown action...");

                action();
            }
        }

        /// <summary>
        /// Executes the specified task.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        /// <param name="context">The context.</param>
        public void Execute(CakeTask task, ICakeContext context)
        {
            if (task != null)
            {
                _log.Information(string.Empty);
                _log.Information("========================================");
                _log.Information(task.Name);
                _log.Information("========================================");
                _log.Verbose("Executing task: {0}", task.Name);

                task.Execute(context);

                _log.Verbose("Finished executing task: {0}", task.Name);
            }
        }

        /// <summary>
        /// Skips the specified task.
        /// </summary>
        /// <param name="task">The task to skip.</param>
        public void Skip(CakeTask task)
        {
            if (task != null)
            {
                _log.Verbose("Skipping task: {0}", task.Name);
            }
        }

        /// <summary>
        /// Executes the error reporter.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exception">The exception.</param>
        public void ReportErrors(Action<Exception> action, Exception exception)
        {
            if (action != null)
            {
                action(exception);
            }
        }

        /// <summary>
        /// Executes the error handler.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exception">The exception.</param>
        public void HandleErrors(Action<Exception> action, Exception exception)
        {
            if (action != null)
            {
                action(exception);
            }
        }

        /// <summary>
        /// Invokes the finally handler.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeFinally(Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}