using System;
public class SonidoException : Exception {
    public SonidoException () { }

    public SonidoException (string message) : base (message) { }

    public SonidoException (string message, Exception inner) : base (message, inner) { }
}