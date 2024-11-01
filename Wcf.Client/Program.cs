using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Wcf.Client
{
	[ServiceContract]
	public interface IMessageService
	{
		[OperationContract]
		string[] GetMessage();
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
			string url = "net.tcp://localhost/6565/MessageService";
			NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
			var channel=new ChannelFactory<IMessageService>(binding);
			var endpoint = new EndpointAddress(url);
			var proxy=channel.CreateChannel(endpoint);
			var result = proxy?.GetMessage();
			if (result != null)
			{
				result.ToList().ForEach(p => { Console.WriteLine(p); });
			}
			Console.ReadLine() ;
		}
	}
}
