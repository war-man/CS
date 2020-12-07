using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class RoomResponse
    {
        public int Total { get; set; }
        public List<Room> Data { get; set; }
    }
}
