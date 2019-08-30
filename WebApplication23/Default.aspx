<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication23._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox runat="server" ID="product"></asp:TextBox>


    <asp:Button OnCommand="tab0tab1"  Text="Add Product" runat="server"/>
    <asp:Button runat="server" OnCommand="vairent" Text="Add varient"/>

    <asp:GridView runat="server" DataSourceID="sql">
        <Columns>
        <asp:TemplateField>
            <ItemTemplate><a href="Default.aspx?id=<%# Eval("Id")%>">He</a>
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
    </asp:GridView>

    <asp:GridView ID="varients" runat="server">
      
    </asp:GridView>
    
    <asp:SqlDataSource ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucky\source\repos\WebApplication23\WebApplication23\App_Data\Database2.mdf;Integrated Security=True"
        
               
        runat="server" SelectCommand="select * from sku" ID="sql">


    </asp:SqlDataSource>
    <%--<script type="text/javascript" src="//downloads.mailchimp.com/js/signup-forms/popup/unique-methods/embed.js" data-dojo-config="usePlainJson: true, isDebug: false"></script><script type="text/javascript">window.dojoRequire(["mojo/signup-forms/Loader"], function(L) { L.start({"baseUrl":"mc.us3.list-manage.com","uuid":"27ac3832478c09b619816d2a8","lid":"c33d5c02bb","uniqueMethods":true}) })</script>--%>
   


</asp:Content>
