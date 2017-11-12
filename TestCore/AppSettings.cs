using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore
{
    public class AppSettings
    {
        public string MyNodeName { get; set; }
        public List<BlockchainNode> Nodes { get; set; }
    }
}
