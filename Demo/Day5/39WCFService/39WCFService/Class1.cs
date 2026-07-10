using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;

namespace _39WCFService
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract] // 이 속성을 붙여야 외부에서 사용가능
        string Hello(string s);

        [OperationContract] // 이 속성을 붙여야 외부에서 사용가능
        DataSet GetMembers();
    }
    public class HelloService : IHelloService
    {
        public DataSet GetMembers()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=Test;integrated security=true";
            SqlDataAdapter adapter = new SqlDataAdapter("select * from member", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public string Hello(string s)
        {
            return "Hello," + s;
        }
    }
}
