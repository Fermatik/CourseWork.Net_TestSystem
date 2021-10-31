using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum TypeMessage
    {
        ClientMessage,
        ServerMessage,
        ClientClose,
        ServerClose,
        AutorizationRequest,
        AutorizationResponse,
        ListTestRequest,
        ListTestResponse,
        TestRequest,
        TestResponse,
        ResultTest,
        ResultTestRequest,
        ResultTestResponse
    }
}
