﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DalPiaz.Model
{

	[XmlRoot(ElementName = "position")]
	public class Position
	{

		[XmlElement(ElementName = "mobile")]
		public string Mobile { get; set; }

		[XmlElement(ElementName = "date")]
		public string Date { get; set; }

		[XmlElement(ElementName = "lat")]
		public double Lat { get; set; }

		[XmlElement(ElementName = "lon")]
		public double Lon { get; set; }

		//[XmlElement(ElementName = "velocity")]
		//public int Velocity { get; set; }

		//[XmlElement(ElementName = "course")]
		//public int Course { get; set; }

		[XmlElement(ElementName = "id")]
		public int Id { get; set; }
	}

	[XmlRoot(ElementName = "positions")]
	public class Positions
	{

		[XmlElement(ElementName = "position")]
		public Position Position { get; set; }
	}


}
