<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<meta charset="utf-8">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 2632px;
            height: 2628px;
        }
        .Layout-img
        {
            background:url("/2BHK.png");
            background-repeat:no-repeat;
            background-position:center;
           background-size:80% 100%;
           height:700px;
        }
        #MasterBedRoomButton
        {
            position:absolute;
            align-content:center;
            margin-left:370px;
        }

        #BedRoomButton
        {
            position:inherit;
            margin-left:150px;
        }

         #BedRoomToiletButton
        {
            position:absolute;
            margin-left:40px;
        }

         #MasterBedRoomToiletButton
        {
            position:inherit;
            margin-left:400px;
        }

         #FamilyRoonToiletButton
        {
            position:absolute;
            margin-left:40px;
        }
            #DinningRoomButton
        {
            position:inherit;
            margin-left:400px;
        }

         #FamilyRoomButton
        {
            position:absolute;
            margin-left:150px;
        }


          #KitchenRoomButton
        {
            position:inherit;
            margin-left:400px;
        }

              #LivingRoomButton
        {
            position:inherit;
            margin-left:150px;
        }


     </style>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    
    <div class="container-fluid">

    <form id="form1" runat="server">
            
    <div class="col-sm-12">    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        
        <asp:Button ID="ServerResponseBtton" runat="server" OnClick="onclick" Text="Button" />
    </div>  
              
        <div id="Response" runat="server"></div> <br />
        <div id="LinkCheck" runat="server"></div> <br />
        <div id="LightStatus" runat="server"></div>

         <div ID="Test" runat="server">HAI I am Test Am i Helpful </div>

    <div class="Layout-img row">
        <br /><br /><br /><br /><br /><br /><br />

        <div class="row col-sm-12">
        <div class="butone col-sm-6">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                    <asp:ImageButton ID="MasterBedRoomButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange" />
                </fieldset>
            </ContentTemplate>
                 <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
   </Triggers>
        </asp:UpdatePanel> 
            <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
</asp:Timer>
       
        </div>
              
        <div class="butwo col-sm-3">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <fieldset>
                
                <asp:ImageButton ID="BedRoomButton" runat="server" OnClick="bgchange" ImageUrl="~/TL2_30X30.PNG" /> 
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>                  
        </div>   
        
         <div class="buthr col-sm-3">
             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset>
             
                <asp:ImageButton ID="BedRoomToiletButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>            
            </div> 
            </div>

        <br /><br /><br /><br /><br />

         <div class="row col-sm-12">
        <div class="butone col-sm-6">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <fieldset>
                
                <asp:ImageButton ID="MasterBedRoomToiletButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>         
        </div>
              
        <div class="butwo col-sm-3">
                
        </div>   
        
         <div class="buthr col-sm-3">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <fieldset>
                
                <asp:ImageButton ID="FamilyRoonToiletButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>           
            </div> 
            </div>

        <br /><br /><br /><br /><br /><br />
        <div class="row col-sm-12">
        <div class="butone col-sm-6">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <fieldset>                
                 <asp:ImageButton ID="DinningRoomButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>       
        </div>                    
         <div class="buthr col-sm-3">
              <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <fieldset>                
                 <asp:ImageButton ID="FamilyRoomButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>            
            </div> 
            </div>

           <br /><br /><br /><br /><br /><br /><br /><br />

         <div class="row col-sm-12">
        <div class="butone col-sm-6">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <fieldset>                
                <asp:ImageButton ID="KitchenRoomButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>        
        </div>
              
       
        
         <div class="buthr col-sm-6">
              <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <fieldset>                
                <asp:ImageButton ID="LivingRoomButton" runat="server" ImageUrl="~/TL2_30X30.PNG" OnClick="bgchange"/>
                </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>            
            </div> 
            </div>


           
     </div>        
    </form>         
   </div>      
 
</body>
</html>
