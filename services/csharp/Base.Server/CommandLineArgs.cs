using System.Linq.Expressions;
using CommandLine;

namespace Improbable.OnlineServices.Base.Server
{
    public class CommandLineArgs
    {
        [Option("hostname", HelpText = "Server host IP", Default = "0.0.0.0")]
        public string HostName { get; set; }

        [Option("ssl_certificate_chain", HelpText = "File path for SSL certificate chain (PEM).")]
        public string SslCertChainPath { get; set; }

        [Option("ssl_private_key", HelpText = "File path for SSL private key (PEM).")]
        public string SslPrivateKeyPath { get; set; }

        [Option("grpc_service_port", HelpText = "Port for gRPC Services.", Default = 4040)]
        public int GrpcServicePort { get; set; }

        [Option("metrics_port", HelpText = "Port to expose Prometheus Metrics.", Default = 8080)]
        public int MetricsPort { get; set; }

        [Option("disable_prometheus", HelpText = "If present, Prometheus will not be used for gathering metrics.", Default = true)]
        public bool DisablePrometheus { get; set; }
    }
}
