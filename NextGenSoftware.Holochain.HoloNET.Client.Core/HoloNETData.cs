﻿
using MessagePack;

namespace NextGenSoftware.Holochain.HoloNET.Client.Core
{
    [MessagePackObject]
    public class HoloNETData
    {
        [Key(0)]
        public string cap { get; set; } //CapSecret | null = string

        [Key(1)]
        public string[,] cell_id { get; set; } = new string[1, 2]; //CellId = [HoloHash, AgentPubKey] = [string, string] = 2 dimensional array.

        [Key(2)]
        public string zome_name { get; set; }

        [Key(3)]
        public string fn_name { get; set; }

        [Key(4)]
        public byte[] payload { get; set; } //Payload - What is Payload object?

        [Key(5)]
        public string provenance { get; set; } //AgentPubKey = string
    }
}