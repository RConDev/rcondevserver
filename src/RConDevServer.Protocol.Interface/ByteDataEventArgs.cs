using System;

namespace RConDevServer.Protocol.Interface
{
    public class ByteDataEventArgs : EventArgs
    {
        public byte[] ByteData { get; private set; }

        public ByteDataEventArgs(byte[] byteData)
        {
            ByteData = byteData;
        }
    }
}