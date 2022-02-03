using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Base class to unit test exception
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

#pragma warning disable SYSLIB0011 // obsolete
            new BinaryFormatter().Serialize(stream, exception);
#pragma warning restore SYSLIB0011 // obsolete

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
#pragma warning disable SYSLIB0011 // obsolete
            return (TException)new BinaryFormatter().Deserialize(stream);
#pragma warning restore SYSLIB0011 // obsolete
        }
    }
}
