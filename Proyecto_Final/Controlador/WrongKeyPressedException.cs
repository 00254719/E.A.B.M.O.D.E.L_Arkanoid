using System;

namespace Arkanoid.Controlador
{
    public class WrongKeyPressedException : Exception
    {
        public WrongKeyPressedException(string Message) : base(Message) { }
    }
}
