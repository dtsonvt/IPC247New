using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
	public class ERRORLOG
	{
		public string IP { get; set; }
		public string Form { get; set; }
		public string Event { get; set; }
		public string ErrorDescription { get; set; }
		public ERRORLOG(string _IP,string  _Form, string _Event, string _ErrorDescription)
		{
			IP = _IP; Form = _Form; Event = _Event; ErrorDescription = _ErrorDescription;
		}
	}
}
