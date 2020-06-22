using System;

namespace Arkanoid.Controlador
{
    public class NoRemainingLifesException : Exception
    {
        public NoRemainingLifesException(string Message) : base(Message) { }
    }
}
