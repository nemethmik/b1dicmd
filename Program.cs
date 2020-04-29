using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1dicmd {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello");
			try {
				SAPbobsCOM.Company company = new SAPbobsCOM.Company();
				company.CompanyDB = "SBODemoUS";
				company.Server = "MIKISURFACE";
				company.LicenseServer = "MIKISURFACE:30000";
				company.SLDServer = "MIKISURFACE:40000";
				company.DbUserName = "sa";
				company.DbPassword = "B1Admin";
				company.UseTrusted = true;
				company.UserName = "manager";
				company.Password = "B1Admin";
				company.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016;
				int status = company.Connect();
				string errorMsg = company.GetLastErrorDescription();
				int errorCode = company.GetLastErrorCode();
				System.Diagnostics.Debug.WriteLine($"Connection Status {status} msg {errorMsg} code {errorCode}");
				SAPbobsCOM.RecordsetEx rs = company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordsetEx);
				rs.DoQuery("select * from OITM");
				rs.MoveNext();
				string ic = rs.GetColumnValue("ItemCode");
				System.Diagnostics.Debug.WriteLine($"Item Code is {ic}");
				company.Disconnect();
				System.Diagnostics.Debug.WriteLine("Disconnected");
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e.Message);
			}
		}
	}
}
