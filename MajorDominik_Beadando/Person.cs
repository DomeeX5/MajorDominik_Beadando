using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MajorDominik_Beadando
{
	public class Person
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("Email")]
		public string Email { get; set; }
		[JsonProperty("Full Name")]
		public string Name { get; set; }
		[JsonProperty("Phone Number")]
		public string Phone { get; set; }

		public override string ToString()
		{
			return $"Azonosító: {this.Id}\nNév: {this.Name}\nEmail: {this.Email}\nTelefonszám: {this.Phone}";
		}
	}

}
