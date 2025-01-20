using NLog;

namespace WebApplicationMustToHave.Services
{
    /// <summary>
    /// Интерфейс для логирования
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// Метод для логирования уровня Information
        /// </summary>
        /// <param name="message"></param>
        void LogInformation(string message);
        /// <summary>
        /// Метод для логирования уровня Warning
        /// </summary>
        /// <param name="message"></param>
        void LogWarning(string message);
        /// <summary>
        /// Метод для логирования уровня Debug
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);
        /// <summary>
        /// Метод для логирования уровня Error
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }

    /// <summary>
    /// Класс для логирования
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Конструктор
        /// </summary>
        public LoggerManager()
        {
        }

        /// <summary>
        /// Метод для логирования уровня Debug
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Метод для логирования уровня Error
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Метод для логирования уровня Information
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Метод для логирования уровня Warning
        /// </summary>
        /// <param name="message"></param>
        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}
