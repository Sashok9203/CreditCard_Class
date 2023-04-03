using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard_Class
{
    internal class CreditCard
    {
		private string? _name;
        private string? _number;
        private int _cvv;
        private DateTime _expiration_date;

		public CreditCard() : this("DefName", "0000 0000 0000 0000", 000, 2050, 1, 1) { }
        public CreditCard(string? name,string? number,int cvv,int year,int month,int day)
        {
            CVV = cvv;
			Name = name;
			Number = number;
            ExpirationDate = new DateTime(year, month, day);
        }
        public string Name
		{
			get => _name ?? "Error name";
			set 
			{
				if (string.IsNullOrWhiteSpace(value)) throw new ApplicationException(" The name cannot be empty...");
				foreach (var item in value)
					if(!Char.IsLetter(item)) throw new ApplicationException($" The name must contain letters only  \"{item}\"...");
                _name = value;
			}
		}
	    public string Number
		{
			get => _number ?? "Error number";
			set 
			{
		     	uint count = 1; 
                StringBuilder sb = new StringBuilder();
				foreach (var item in value)
				{
					if (!Char.IsWhiteSpace(item))
					{
						if (Char.IsDigit(item))
						{
							sb.Append(item + (count <= 12 && count % 4 == 0 ? " " : ""));
							count++;
						}
						else throw new ApplicationException($" The number must contain digits only  \"{item}\"...");
                    }
				}
				value = sb.ToString();
            	if(value.Length != 19) throw new ApplicationException(" Invalid gigits count in card number , must be 16 ...");
                _number = value;
			}
		}
    	public int CVV
		{
			get => _cvv; 
			set 
			{
				if (value < 100 || value > 999) throw new ApplicationException($" Invalid CVV {value}");
				_cvv = value;
			}
		}
		public DateTime ExpirationDate
		{
			get => _expiration_date;
			set 
			{
				if(value <= DateTime.Now ) throw new ApplicationException($" Invalid expiration date \"{value.ToShortDateString()}\"...");
                _expiration_date = value;
			}
		}
        public override string ToString()
        {
			StringBuilder sb  = new StringBuilder($"    -= Credit card =-\n");
            sb.AppendLine($" Name      : {_name}");
            sb.AppendLine($" Number    : {Number}");
            sb.AppendLine($" Exp. date : {_expiration_date.ToShortDateString()}");
            sb.AppendLine($" CVV       : {_cvv}");
            return sb.ToString();
        }
    }
}
