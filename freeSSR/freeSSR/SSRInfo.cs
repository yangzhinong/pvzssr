using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace freeSSR
{
    class Server
    {
        public static int i = 0;

        public Server()
        {
            i++;
            remarks = "server" + i.ToString();
        }

        public string id { get; set; }
        public string server { get; set; }

        public int server_port { get; set; }

        public string password { get; set; }

        public string method { get; set; }

        public bool enable { get; set; } = true;

        public string remarks { get; set; }

        public string remarks_base64 { get; set; } = "5pCs55Om5bel";
        public string protocol { get; set; } = "origin";

        public string obfsparam { get; set; } = "";

        public string obfs { get; set; } = "plain";

        public bool tcp_over_udp { get; set; }

        public bool udp_over_tcp { get; set; }

        public bool obfs_udp { get; set; }

        public string time { get; set; }

        public string rate { get; set; }

        public string group { get; set; } = "FreeSSR-public";
    }

    [Serializable]
    class SSR
    {
        public List<Server> configs;
        public int index;
        public bool random;
        public int sysProxyMode;
        public bool shareOverLan;
        public int localPort;
        public string localAuthPassword;

        public string dnsServer;
        public int reconnectTimes;
        public string balanceAlgorithm;
        public bool randomInGroup;
        public int TTL;
        public int connectTimeout;

        public int proxyRuleMode;

        public bool proxyEnable;
        public bool pacDirectGoProxy;
        public int proxyType;
        public string proxyHost;
        public int proxyPort;
        public string proxyAuthUser;
        public string proxyAuthPass;
        public string proxyUserAgent;

        public string authUser;
        public string authPass;

        public bool autoBan;
        public bool sameHostForSameTarget;

        public int keepVisitTime;

        public bool isHideTips;

        public bool nodeFeedAutoUpdate;
        public List<ServerSubscribe> serverSubscribes;

        public Dictionary<string, string> token = new Dictionary<string, string>();
        public Dictionary<string, PortMapConfig> portMap = new Dictionary<string, PortMapConfig>();
    }
    [Serializable]
    public class ServerSubscribe
    {
        private static string DEFAULT_FEED_URL = "https://raw.githubusercontent.com/shadowsocksrr/breakwa11.github.io/master/free/freenodeplain.txt";
        //private static string OLD_DEFAULT_FEED_URL = "https://raw.githubusercontent.com/shadowsocksrr/breakwa11.github.io/master/free/freenode.txt";

        public string URL = DEFAULT_FEED_URL;
        public string Group;
        public UInt64 LastUpdateTime;
    }


    [Serializable]
    public class PortMapConfig
    {
        public bool enable;
        public PortMapType type;
        public string id;
        public string server_addr;
        public int server_port;
        public string remarks;
    }
    public enum PortMapType : int
    {
        Forward = 0,
        ForceProxy,
        RuleProxy
    }
}
