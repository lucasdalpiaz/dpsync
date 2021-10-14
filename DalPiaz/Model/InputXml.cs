using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DalPiaz.Model
{


	[XmlRoot(ElementName = "payload")]
	public class Payload
	{

		[XmlAttribute(AttributeName = "encoding")]
		public string Encoding { get; set; }

		[XmlAttribute(AttributeName = "source")]
		public string Source { get; set; }

		[XmlAttribute(AttributeName = "length")]
		public int Length { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "stuMessage")]
	public class StuMessage
	{

		[XmlElement(ElementName = "esn")]
		public string Esn { get; set; }

		[XmlElement(ElementName = "unixTime")]
		public int UnixTime { get; set; }

		[XmlElement(ElementName = "gps")]
		public string Gps { get; set; }

		[XmlElement(ElementName = "payload")]
		public Payload Payload { get; set; }
	}

	[XmlRoot(ElementName = "stuMessages")]
	public class StuMessages
	{

		[XmlElement(ElementName = "stuMessage")]
		public List<StuMessage> StuMessage { get; set; }

		[XmlAttribute(AttributeName = "messageID")]
		public string MessageID { get; set; }

		[XmlAttribute(AttributeName = "timeStamp")]
		public string TimeStamp { get; set; }

		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation")]
		public string NoNamespaceSchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlText]
		public string Text { get; set; }
	}



}
