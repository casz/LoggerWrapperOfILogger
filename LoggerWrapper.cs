using System;
using Microsoft.Extensions.Logging;

namespace LoggerWrapperOfILogger
{
    public class LoggerWrapper<T> : ILogger<T>
    {
        private readonly ILogger _inner;
        public LoggerWrapper(ILogger inner)
        {
            _inner = inner;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _inner.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _inner.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _inner.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}
