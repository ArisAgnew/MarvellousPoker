using System;
using System.Runtime.Serialization;

namespace MarvellousPoker.Meta.CustomExceptions
{
    /*
     * При обработке исключения, производного от System.ApplicationException, можно смело предполагать, 
     * что исключение было инициировано кодом работающего приложения, а не сторонней библиотекой.
     */
    [Serializable]
    internal class GameGeneralException : ApplicationException
    {
        private string _gameExceptionMessage;

        public string GameExceptionMessage
        {
            get => _gameExceptionMessage;
            set
            {
                if (_gameExceptionMessage != value)
                {
                    _gameExceptionMessage = value;
                }
            }
        }

        public GameGeneralException()
        {
        }

        public GameGeneralException(string message) : base(message)
        {
        }

        public GameGeneralException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GameGeneralException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _gameExceptionMessage = info?.GetString(nameof(GameExceptionMessage));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(GameExceptionMessage), GameExceptionMessage);
        }
    }
}
