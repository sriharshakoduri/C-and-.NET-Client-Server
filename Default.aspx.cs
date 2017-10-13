using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;
using System.Drawing;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{

    public int MasterBedroomStatus = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
       getStatus();
    }

    private void getStatus()
    {
        byte[] data = new byte[1024];
        //string input, stringData;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.151"), 234);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        Random Statreq = new Random();
        int index = Statreq.Next(0, 5);


        Statusobject stobj = new Statusobject
        {
            Request = "GetControlStatus",
            RequestID = index.ToString(),
            Controls = new Control[] { new Control() { ID = "37", StatusValue = "255" } },
            Version = "1501603666",
            RequestedBy = "DefaultUser"
        };


        string output = JsonConvert.SerializeObject(stobj);
        data = Encoding.ASCII.GetBytes(output);
        server.SendTo(data, data.Length, SocketFlags.None, ipep);               //Send Request to Server
        EndPoint Remote = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
        data = new byte[1024];

        int recv = server.ReceiveFrom(data, ref Remote);                        //Reseive Response from Server
        Response.InnerHtml = Server.HtmlEncode("Message received from {0}:" + Remote);

        string json = data.ToString();

        ResponseObj Deserial = JsonConvert.DeserializeObject<ResponseObj>(Encoding.ASCII.GetString(data, 0, recv));

        LinkCheck.InnerHtml = Server.HtmlEncode("\n This is output\t" + Deserial.Data.ControlStatus[0].StatusValue + "\n\nTIME" + DateTime.Now);

        var ha = Deserial.Data.ControlStatus[0].StatusValue;

        int StatuValueInt = Convert.ToInt32(ha);

        if(StatuValueInt > 0)
        {
            MasterBedroomStatus = 1;
            
            MasterBedRoomButton.BackColor = Color.White;

        }
        else
        {
            MasterBedroomStatus = 0;
            
            MasterBedRoomButton.BackColor = Color.LightGray;
        }
        



    }


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Random r = new Random();
        int index = r.Next(0, 5);
        LinkCheck.InnerHtml = Server.HtmlEncode(index.ToString());
        getStatus();

    }



    protected void onclick(object sender, EventArgs e)
    {
        byte[] data = new byte[1024];
        //string input, stringData;

        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.151"), 234);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        Random Statreq1 = new Random();
        int index1 = Statreq1.Next(0, 5);


        Requestobject obj1 = new Requestobject
        {
            Request = "LinkCheck",
            RequestID = index1.ToString(),
            Version = "1501603666"
        };


        string output = JsonConvert.SerializeObject(obj1);
        Console.WriteLine(output);
        data = Encoding.ASCII.GetBytes(output);
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        EndPoint Remote = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
        data = new byte[1024];

        int recv = server.ReceiveFrom(data, ref Remote);
        Response.InnerHtml = Server.HtmlEncode("Message received from {0}:" + Remote);

        LinkCheck.InnerHtml = Server.HtmlEncode(Encoding.ASCII.GetString(data, 0, recv) + "TIME" + DateTime.Now);

        Random Statreq = new Random();
        int index = Statreq.Next(0, 5);


        Statusobject stobj = new Statusobject
        {
            Request = "GetControlStatus",
            RequestID = index.ToString(),
            Controls = new Control[] { new Control() { ID = "37", StatusValue = "255" } },
            Version = "1501603666",
            RequestedBy = "DefaultUser"
        };


        output = JsonConvert.SerializeObject(stobj);
        Console.WriteLine(output);
        data = Encoding.ASCII.GetBytes(output);
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        sender = new IPEndPoint(IPAddress.Any, 0);
        Remote = (EndPoint)(sender);
        data = new byte[1024];

        recv = server.ReceiveFrom(data, ref Remote);
        Console.WriteLine("Message received from {0}:", Remote.ToString());

        Console.WriteLine(recv);

        Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
        LightStatus.InnerHtml = Server.HtmlEncode(Encoding.ASCII.GetString(data, 0, recv));



    }
    public class Requestobject
    {
        public string Request { get; set; }
        public string RequestID { get; set; }
        public string Version { get; set; }
    }

    public class Control
    {

        public string ID { get; set; }
        public string StatusValue { get; set; }
    }


    public class Statusobject
    {
        public string Request { get; set; }
        public string RequestID { get; set; }
        public Control[] Controls { get; set; }
        public string Version { get; set; }
        public string RequestedBy { get; set; }
    }


    public class ResponseObj
    {
        public string ResponseFor { get; set; }
        public int RequestID { get; set; }
        public Data Data { get; set; }
        public string ResponseFlag { get; set; }
    }

    public class Data
    {
        public Controlstatu[] ControlStatus { get; set; }
    }

    public class Controlstatu
    {
        public int ID { get; set; }
        public int StatusValue { get; set; }
        public string LastOperationTime { get; set; }
        public int OperationType { get; set; }
        public string OperatedBy { get; set; }
        public int State { get; set; }
    }

    public class SwitchControl
    {


        public string Request { get; set; }
        public string RequestID { get; set; }
        public Control[] Controls { get; set; }
        public string Version { get; set; }
        public string RequestedBy { get; set; }
    }




    public static int  b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0, b9 = 0;


    public void bgchange(object sender, ImageClickEventArgs e)
    {
        ImageButton clickedButton = sender as ImageButton;

        if (clickedButton.ID == "MasterBedRoomButton")
        {
             
            if (MasterBedroomStatus == 0)
            {
                clickedButton.BackColor = Color.White;
                SwitchOn(sender,e);
                Test.InnerHtml = Server.HtmlEncode("Test On");
                MasterBedroomStatus = 1;
            }
            else
            {
                clickedButton.BackColor = Color.LightGray;
                SwitchOff(sender, e);
                Test.InnerHtml = Server.HtmlEncode("Test Off");
                MasterBedroomStatus = 0;
            }

        }

       else if (clickedButton.ID == "BedRoomButton")
        {
            if (b2 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b2 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b2 = 0;
            }

        }


        else if (clickedButton.ID == "BedRoomToiletButton")
        {
            if (b3 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b3 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b3 = 0;
            }

        }


        else if (clickedButton.ID == "MasterBedRoomToiletButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }

        else if (clickedButton.ID == "FamilyRoonToiletButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }

        else if (clickedButton.ID == "DinningRoomButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }
        else if (clickedButton.ID == "FamilyRoomButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }

        else if (clickedButton.ID == "KitchenRoomButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }
        else if (clickedButton.ID == "LivingRoomButton")
        {
            if (b4 == 0)
            {
                clickedButton.BackColor = Color.LightGray;
                b4 = 1;
            }
            else
            {
                clickedButton.BackColor = Color.White;
                b4 = 0;
            }

        }



    }

    public void SwitchOn(object sender, ImageClickEventArgs e)
    {
        byte[] data = new byte[1024];
        //string input, stringData;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.151"), 234);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        Random Statreq = new Random();
        int index = Statreq.Next(0, 5);


        SwitchControl swt = new SwitchControl
        {
            Request = "SwitchControl",
            RequestID = index.ToString(),
            Controls = new Control[] { new Control() { ID = "37", StatusValue = "255" } },

            Version = "1501603666",
            RequestedBy = "DefaultUser"
        };

        string output = JsonConvert.SerializeObject(swt);

         data = Encoding.ASCII.GetBytes(output);
        Console.WriteLine(Encoding.ASCII.GetString(data));

        Test.InnerHtml = "data";
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint Remote = (EndPoint)(sender);
        data = new byte[1024];

        int recv = server.ReceiveFrom(data, ref Remote);
        Console.WriteLine("Message received from {0}:", Remote.ToString());

        Console.WriteLine(recv);

        Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
        LightStatus.InnerHtml = Server.HtmlEncode(Encoding.ASCII.GetString(data, 0, recv));
    }


    public void SwitchOff(object sender, ImageClickEventArgs e)
    {
        byte[] data = new byte[1024];
        //string input, stringData;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.151"), 234);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        Random Statreq = new Random();
        int index = Statreq.Next(0, 5);

        SwitchControl swtOff = new SwitchControl
        {
            Request = "SwitchControl",
            RequestID = index.ToString(),
            Controls = new Control[] { new Control() { ID = "37", StatusValue = "0" } },
            Version = "1501603666",
            RequestedBy = "DefaultUser"
        };

        string output = JsonConvert.SerializeObject(swtOff);

        data = Encoding.ASCII.GetBytes(output);
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint Remote = (EndPoint)(sender);
        data = new byte[1024];

        int recv = server.ReceiveFrom(data, ref Remote);

        
        LightStatus.InnerHtml = Server.HtmlEncode(Encoding.ASCII.GetString(data, 0, recv));
    }



}