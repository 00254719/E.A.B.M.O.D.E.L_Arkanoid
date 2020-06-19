using System;

namespace Arkanoid.Controlador
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string Message) : base(Message) { }
    }
}
