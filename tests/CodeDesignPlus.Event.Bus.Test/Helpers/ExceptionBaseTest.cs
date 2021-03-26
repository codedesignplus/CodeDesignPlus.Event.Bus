using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Clase base para las pruebas unitarias
    /// </summary>
    public abstract class ExceptionBaseTest
    {
        /// <summary>
        /// Serialize Exception
        /// </summary>
        /// <typeparam name="TException">Type Exception</typeparam>
        /// <param name="exception">Exception to serialize</param>
        /// <returns>Return bytes[]</returns>
        protected virtual byte[] SerializeToBytes<TException>(TException exception) where TException : Exception
        {
            using var stream = new MemoryStream();

            new BinaryFormatter().Serialize(stream, exception);

            return stream.GetBuffer();
        }

        /// <summary>
        /// Deserialize Exception
        /// </summary>
        /// <typeparam name="TException">Type Exception</typeparam>
        /// <param name="bytes">bytes[] exception</param>
        /// <returns>Return exception of type <typeparamref name="TException"/></returns>
        protected virtual TException DeserializeFromBytes<TException>(byte[] bytes) where TException : Exception
        {
            using var stream = new MemoryStream(bytes);
            return (TException)new BinaryFormatter().Deserialize(stream);
        }
    }
}
