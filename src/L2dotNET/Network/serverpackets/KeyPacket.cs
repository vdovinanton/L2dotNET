﻿namespace L2dotNET.Network.serverpackets
{
    class KeyPacket : GameserverPacket
    {
        private readonly byte[] _key;
        private byte _next;

        public KeyPacket(GameClient client, byte n)
        {
            _key = client.EnableCrypt();
            _next = n;
        }

        public override void Write()
        {
            WriteByte(0x00);
            WriteByte(0x01);
            WriteBytesArray(_key);
            WriteInt(0x01);
            WriteInt(0x01);
        }
    }
}