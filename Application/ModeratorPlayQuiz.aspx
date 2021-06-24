<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeratorPlayQuiz.aspx.cs" Inherits="Application.ModeratorPlayQuiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PlayQuiz</title>
    <link href="Content/ModeratorPlayQuiz.css" rel="stylesheet" />  
    <link href="Content/bootstrap.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
       
        

        <div class="Code"> 

             <asp:Label ID="CodeAccess" runat="server" Text="Kod za pristup kvizu: "></asp:Label>
                 <br />   
              <asp:Label ID="TextCode" runat="server" Height="39px" Width="151px"></asp:Label>  
            
        </div>           
        
        <div class="Buttons">
                
             <asp:Button ID="Exit" runat="server" Text="Izađi iz kviza" Height="100px" Width="225px" OnClick="Exit_Click" class="btn btn-danger"/>
             <asp:Button ID="Play" runat="server" Text="Pokreni kviz" Height="100px" Width="225px" OnClick="Play_Click"  class="btn btn-success"/>
              
        </div>    

         <div class="Players">
           
            
             <asp:Label ID="PlayersNumber" runat="server" Text="Broj igrača: "></asp:Label>
                 <br />   
              <asp:Label ID="TextPlayers" runat="server" Height="39px" Width="170px"></asp:Label>
         
            
         </div> 
            
           

   </form>
 </body>
</html>
